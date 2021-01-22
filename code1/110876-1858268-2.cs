    public class Zombie
    {
        public int BrainsConsumed { get; set; }
        static void Main() {
            Zombie steve = new Zombie { BrainsConsumed = 2 };
            Test.ShouldBeEqual(() => steve.BrainsConsumed, 0);
        }
    
    }
    public static class Test
    {
        static string GetName(Expression expr)
        {
            if (expr.NodeType == ExpressionType.MemberAccess)
            {
                var me = (MemberExpression)expr;
                string name = me.Member.Name, subExpr = GetName(me.Expression);
                return string.IsNullOrEmpty(subExpr)
                    ? name : subExpr + "." + name;
            }
            return "";
        }
        public static void ShouldBeEqual<TValue>(
            Expression<Func<TValue>> selector,
            TValue expected)
        {
            TValue value = selector.Compile()();
    
            string name = GetName(selector.Body);
            
            System.Diagnostics.Debug.Assert(
                EqualityComparer<TValue>.Default.Equals(value, expected),
                typeof(TValue) + " " + name + ": " +
                    value + " doesn't match expected " + expected);
        }
    }
