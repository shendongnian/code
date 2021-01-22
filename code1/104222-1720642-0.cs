    using System;
    using System.Collections.Generic;
    using System.Linq;    
    using System.Linq.Expressions;
    using System.Reflection;
    
    public class GrandParent
    {
        public Parent Parent { get; set; }
    }
    public class Parent
    {
        public Child Child { get; set; }
        public string Method(string s) { return s + "abc"; }
    }
    
    public class Child
    {
        public string Name { get; set; }
    }
    public static class ExpressionUtils
    {
        public static Expression<Func<T1, T3>> Combine<T1, T2, T3>(
            this Expression<Func<T1, T2>> outer, Expression<Func<T2, T3>> inner, bool inline)
        {
            var invoke = Expression.Invoke(inner, outer.Body);
            Expression body = inline ? new ExpressionRewriter().AutoInline(invoke) : invoke;
            return Expression.Lambda<Func<T1, T3>>(body, outer.Parameters);
        }
    }
    public class ExpressionRewriter
    {
        internal Expression AutoInline(InvocationExpression expression)
        {
            isLocked = true;
            if(expression == null) throw new ArgumentNullException("expression");
            LambdaExpression lambda = (LambdaExpression)expression.Expression;
            ExpressionRewriter childScope = new ExpressionRewriter(this);
            var lambdaParams = lambda.Parameters;
            var invokeArgs = expression.Arguments;
            if (lambdaParams.Count != invokeArgs.Count) throw new InvalidOperationException("Lambda/invoke mismatch");
            for(int i = 0 ; i < lambdaParams.Count; i++) {
                childScope.Subst(lambdaParams[i], invokeArgs[i]);
            }
            return childScope.Apply(lambda.Body);
        }
        public ExpressionRewriter()
        {
             subst = new Dictionary<Expression, Expression>();
        }
        private ExpressionRewriter(ExpressionRewriter parent)
        {
            if (parent == null) throw new ArgumentNullException("parent");
            subst = new Dictionary<Expression, Expression>(parent.subst);
            inline = parent.inline;
        }
        private bool isLocked, inline;
        private readonly Dictionary<Expression, Expression> subst;
        private void CheckLocked() {
            if(isLocked) throw new InvalidOperationException(
                "You cannot alter the rewriter after Apply has been called");
            
        }
        public ExpressionRewriter Subst(Expression from,
            Expression to)
        {
            CheckLocked();
            subst.Add(from, to);
            return this;
        }
        public ExpressionRewriter Inline() {
            CheckLocked();
            inline = true;
            return this;
        }
        public Expression Apply(Expression expression)
        {
            isLocked = true;
            return Walk(expression) ?? expression;
        }
    
        private BinaryExpression Walk(
            Expression expression,
            Func<Expression, Expression, MethodInfo, BinaryExpression> func)
        {
            return Walk(expression, (binExp, left, right) => func(left, right, binExp.Method));
        }
        private BinaryExpression Walk(
            Expression expression,
            Func<Expression, Expression, bool, MethodInfo, BinaryExpression> func)
        {
            return Walk(expression, (binExp, left, right) => func(left, right, binExp.IsLiftedToNull, binExp.Method));
        }
        private BinaryExpression Walk(
            Expression expression,
            Func<Expression, Expression, LambdaExpression, BinaryExpression> func)
        {
            return Walk(expression, (binExp, left, right) => func(left, right, binExp.Conversion));
        }
        private BinaryExpression Walk(
            Expression expression,
            Func<BinaryExpression, Expression, Expression, BinaryExpression> func)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            BinaryExpression binExp = (BinaryExpression)expression;
            Expression newLeft = Walk(binExp.Left), newRight = Walk(binExp.Right);
            if (newLeft == null && newRight == null) return null;
            return func(binExp, newLeft ?? binExp.Left, newRight ?? binExp.Right);
        }
        private UnaryExpression Walk(
            Expression expression,
            Func<Expression, MethodInfo, UnaryExpression> func)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            UnaryExpression unExp = (UnaryExpression)expression;
            Expression newOperand = Walk(unExp.Operand);
            return newOperand == null ? null : func(newOperand, unExp.Method);
        }
        private UnaryExpression Walk(
            Expression expression,
            Func<Expression, Type, MethodInfo, UnaryExpression> func)
        {
            if (expression == null) throw new ArgumentNullException("expression");
            UnaryExpression unExp = (UnaryExpression)expression;
            Expression newOperand = Walk(unExp.Operand);
            return newOperand == null ? null : func(newOperand, unExp.Type, unExp.Method);
        }
        
        // returns null if no need to rewrite that branch, otherwise
        // returns a re-written branch
        private Expression Walk(Expression expression)
        {
            if (expression == null) return null;
            Expression tmp;
            if (subst.TryGetValue(expression, out tmp)) return tmp;
            switch(expression.NodeType) {
    
                case ExpressionType.MemberAccess:
                    {
                        MemberExpression me = (MemberExpression)expression;
                        Expression target = Walk(me.Expression);
                        return target == null ? null : Expression.MakeMemberAccess(target, me.Member);
                    }
                case ExpressionType.Constant:
                case ExpressionType.Parameter:
                    return null; // never a need to rewrite if not already matched
                case ExpressionType.Add: return Walk(expression, Expression.Add);       
                case ExpressionType.Divide: return Walk(expression, Expression.Divide);
                case ExpressionType.Multiply: return Walk(expression, Expression.Multiply);
                case ExpressionType.Subtract: return Walk(expression, Expression.Subtract);
                // why aren't these used?
                //case ExpressionType.AddChecked: return Walk(expression, Expression.AddChecked);  
                //case ExpressionType.MultiplyChecked: return Walk(expression, Expression.MultiplyChecked);
                //case ExpressionType.SubtractChecked: return Walk(expression, Expression.SubtractChecked);
    
                case ExpressionType.And: return Walk(expression, Expression.And);
                case ExpressionType.Or: return Walk(expression, Expression.Or);
                case ExpressionType.ExclusiveOr: return Walk(expression, Expression.ExclusiveOr);
                case ExpressionType.Equal: return Walk(expression, Expression.Equal);
                case ExpressionType.NotEqual: return Walk(expression, Expression.NotEqual);
                case ExpressionType.AndAlso: return Walk(expression, Expression.AndAlso);
                case ExpressionType.OrElse: return Walk(expression, Expression.OrElse);
                case ExpressionType.Power: return Walk(expression, Expression.Power);
                case ExpressionType.Modulo: return Walk(expression, Expression.Modulo);
                case ExpressionType.GreaterThan: return Walk(expression, Expression.GreaterThan);
                case ExpressionType.GreaterThanOrEqual: return Walk(expression, Expression.GreaterThanOrEqual);
                case ExpressionType.LessThan: return Walk(expression, Expression.LessThan);
                case ExpressionType.LessThanOrEqual: return Walk(expression, Expression.LessThanOrEqual);
                case ExpressionType.LeftShift: return Walk(expression, Expression.LeftShift);
                case ExpressionType.RightShift: return Walk(expression, Expression.RightShift);
                
                case ExpressionType.Not: return Walk(expression, Expression.Not);
                case ExpressionType.UnaryPlus: return Walk(expression, Expression.UnaryPlus);
                case ExpressionType.Negate: return Walk(expression, Expression.Negate);
                case ExpressionType.NegateChecked: return Walk(expression, Expression.NegateChecked);
    
                case ExpressionType.Convert: return Walk(expression, Expression.Convert);
                case ExpressionType.ConvertChecked: return Walk(expression, Expression.ConvertChecked);
                case ExpressionType.Coalesce: return Walk(expression, Expression.Coalesce);
                case ExpressionType.Conditional:
                    {
                        ConditionalExpression ce = (ConditionalExpression)expression;
                        Expression test = Walk(ce.Test), ifTrue = Walk(ce.IfTrue), ifFalse = Walk(ce.IfFalse);
                        if (test == null && ifTrue == null && ifFalse == null) return null;
                        return Expression.Condition(test ?? ce.Test, ifTrue ?? ce.IfTrue, ifFalse ?? ce.IfFalse);
                    }
                case ExpressionType.Call:
                    {
                        MethodCallExpression mce = (MethodCallExpression)expression;
                        Expression instance = Walk(mce.Object);
                        List<Expression> args = mce.Arguments.Select(arg => Walk(arg)).ToList();
                        if (instance == null && !args.Any(arg => arg != null)) return null;
                        return Expression.Call(instance, mce.Method, args);
                    }
    
                case ExpressionType.ArrayIndex:
                case ExpressionType.ArrayLength:            
                case ExpressionType.Invoke:
                case ExpressionType.Lambda:
                case ExpressionType.ListInit:
                case ExpressionType.MemberInit:
                case ExpressionType.New:
                case ExpressionType.NewArrayBounds:
                case ExpressionType.NewArrayInit:
                case ExpressionType.Quote:
                case ExpressionType.TypeAs:
                case ExpressionType.TypeIs:            
                    throw new NotImplementedException("Not implemented: " + expression.NodeType);
                default:
                    throw new NotSupportedException("Not supported: " + expression.NodeType);
            }
            
        }
    }
    static class Program
    {
        static void Main()
        {
            var qry = from type in typeof(Expression).Assembly.GetTypes()
                      where type.IsClass && !type.IsAbstract
                        && type.IsSubclassOf(typeof(Expression))
                      select type.FullName;
            Expression<Func<GrandParent, Parent>> myFirst = gp => gp.Parent;
            Expression<Func<Parent, string>> mySecond = p => p.Child.Name;
    
            Expression<Func<GrandParent, string>> outputWithInline = myFirst.Combine(mySecond, false);
            Expression<Func<GrandParent, string>> outputWithoutInline = myFirst.Combine(mySecond, true);
    
            Expression<Func<GrandParent, string>> call =
                    ExpressionUtils.Combine<GrandParent, Parent, string>(
                    gp => gp.Parent, p => p.Method(p.Child.Name), true);
    
            unchecked
            {
                Expression<Func<double, double>> mathUnchecked =
                    ExpressionUtils.Combine<double, double, double>(x => (x * x) + x, x => x - (x / x), true);
            }
            checked
            {
                Expression<Func<double, double>> mathChecked =
                    ExpressionUtils.Combine<double, double, double>(x => x - (x * x) , x => (x / x) + x, true);
            }
            Expression<Func<int,int>> bitwise =
                ExpressionUtils.Combine<int, int, int>(x => (x & 0x01) | 0x03, x => x ^ 0xFF, true);
            Expression<Func<int, bool>> logical =
                ExpressionUtils.Combine<int, bool, bool>(x => x == 123, x => x != false, true);
        }
    }
