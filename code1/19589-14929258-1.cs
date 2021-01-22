NameOf.Property(() => new Order().Status)
    
    
    using System;
    using System.Diagnostics.Contracts;
    using System.Linq.Expressions;
    namespace AgileDesign.Utilities
    {
    public static class NameOf
    {
        ///<summary>
        ///  Returns name of any method expression with any number of parameters either void or with a return value
        ///</summary>
        ///<param name = "expression">
        ///  Any method expression with any number of parameters either void or with a return value
        ///</param>
        ///<returns>
        ///  Name of any method with any number of parameters either void or with a return value
        ///</returns>
        [Pure]
        public static string Method(Expression<Action> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null);
            return ( (MethodCallExpression)expression.Body ).Method.Name;
        }
        ///<summary>
        ///  Returns name of property, field or parameter expression (of anything but method)
        ///</summary>
        ///<param name = "expression">
        ///  Property, field or parameter expression
        ///</param>
        ///<returns>
        ///  Name of property, field, parameter
        ///</returns>
        [Pure]
        public static string Member(Expression<Func<object>> expression)
        {
            Contract.Requires<ArgumentNullException>(expression != null);
            if(expression.Body is UnaryExpression)
            {
                return ((MemberExpression)((UnaryExpression)expression.Body).Operand).Member.Name;
            }
            return ((MemberExpression)expression.Body).Member.Name;
        }
      }
    }
