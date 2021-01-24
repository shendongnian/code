    public static class IQueryableExt {
        public static Expression<Func<TRec, TVal?[]>> SelectExpr<TRec, TVal>(this IEnumerable<string> strExprs) where TVal : struct {
            var p = Expression.Parameter(typeof(TRec), "p");
            var exprs = strExprs.Select(se => {
                var e = se.ParseExpression(p);
                return e.Type.IsNullableType() && e.Type.GetGenericArguments()[0] == typeof(TVal) ? e : Expression.Convert(e, typeof(TVal?));
            }).ToArray();
    
            return Expression.Lambda<Func<TRec, TVal?[]>>(Expression.NewArrayInit(typeof(TVal?), exprs), p);
        }
    
        static char[] operators = { '+', '-', '*', '/' };
        static Regex tokenRE = new Regex($@"(?=[-+*/()])|(?<=[-+*/()])", RegexOptions.Compiled);
        static HashSet<char> hsOperators = operators.ToHashSet();
        static Dictionary<char, ExpressionType> opType = new Dictionary<char, ExpressionType>() {
            { '*', ExpressionType.Multiply },
            { '/', ExpressionType.Divide },
            { '+', ExpressionType.Add },
            { '-', ExpressionType.Subtract }
        };
    
        static int opPriority(char op) => hsOperators.Contains(op) ? Array.IndexOf(operators, op) >> 1 : (op == ')' ? -1 : -2);
    
        public static Expression ParseExpression(this string expr, ParameterExpression dbParam) {
            var opStack = new Stack<char>();
            opStack.Push('(');
            var operandStack = new Stack<Expression>();
    
            foreach (var t in tokenRE.Split(expr).Where(t => !String.IsNullOrEmpty(t)).Append(")")) {
                if (t.Length > 1) // process column name
                    operandStack.Push(Expression.PropertyOrField(dbParam, t));
                else {
                    while (t[0] != '(' && opPriority(opStack.Peek()) >= opPriority(t[0])) {
                        var curOp = opStack.Pop();
                        var right = operandStack.Pop();
                        var left = operandStack.Pop();
                        if (right.Type != left.Type) {
                            if (right.Type.IsNullableType())
                                left = Expression.Convert(left, right.Type);
                            else if (left.Type.IsNullableType())
                                right = Expression.Convert(right, left.Type);
                            else
                                throw new Exception($"Incompatible types for operator{curOp}: {left.Type.Name}, {right.Type.Name}");
                        }
                        operandStack.Push(Expression.MakeBinary(opType[curOp], left, right));
                    }
                    if (t[0] != ')')
                        opStack.Push(t[0]);
                    else
                        opStack.Pop(); // pop (
                }
            }
            return operandStack.Pop();
        }
    
        public static bool IsNullableType(this Type nullableType) =>
        // instantiated generic type only                
            nullableType.IsGenericType &&
            !nullableType.IsGenericTypeDefinition &&
            Object.ReferenceEquals(nullableType.GetGenericTypeDefinition(), typeof(Nullable<>));
    }
