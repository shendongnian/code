        static void WritePropertyNames()
        {
            TestObject lTestObject = new TestObject();
            PropertyInfo[] lProperty = typeof(TestObject).GetProperties();
            List<Expression> lExpressions = new List<Expression>();
            MethodInfo lMethodInfo = typeof(Console).GetMethod("WriteLine", new Type[] { typeof(string) });
            lProperty.ForEach(x =>
            {
                ConstantExpression lConstant = Expression.Constant(x.Name);
                MethodCallExpression lMethodCall = Expression.Call(lMethodInfo, lConstant);
                lExpressions.Add(lMethodCall);
            });
            BlockExpression lBlock = Expression.Block(lExpressions);
            LambdaExpression lLambda = Expression.Lambda<Action>(lBlock, null);
            Action lWriteProperties = lLambda.Compile() as Action;
            lWriteProperties();
        }
