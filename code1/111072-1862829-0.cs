    public static class Test
    {
        static void Main()
        {
            //So:
            myClass mC = new myClass();
    
            mC.first = "ok";
            mC.second = 12;
            mC.third = "ko";
            //then would return its type from definition :
            Tester(() => mC.first); // would return : "mc.first" or "myClass.first" or "first"
            //and 
            Tester(() => mC.second); // would return : "mc.second" or "myClass.second" or "second"
        }
        static string GetName(Expression expr)
        {
            if (expr.NodeType == ExpressionType.MemberAccess)
            {
                var me = (MemberExpression)expr;
                string name = me.Member.Name, subExpr = GetName(me.Expression);
                return string.IsNullOrEmpty(subExpr)
                    ? name : (subExpr + "." + name);
            }
            return "";
        }
        public static void Tester<TValue>(
            Expression<Func<TValue>> selector)
        {
            TValue value = selector.Compile()();
    
            string name = GetName(selector.Body);
    
            Console.WriteLine(name + " = " + value);
        }
    }
