    private static T RunExpression<T>(Expression<Func<T>> run )
    		{
    			var callExpression = (MethodCallExpression) run.Body;
    
    			var procedureName = callExpression.Method.Name;
    
    			Trace.WriteLine(procedureName);
    
    			foreach (var argument in callExpression.Arguments)
    			{
    				Trace.WriteLine(argument);
    			}
    
    			Trace.WriteLine(callExpression.Arguments.Count);
    			
                        // Some really wicked stuff to assign out parameter
                        // Just for demonstration purposes
    			var outMember = (MemberExpression)callExpression.Arguments[1];
    
    			var e = Expression.Lambda<Func<object>>(outMember.Expression);
    			var o = e.Compile().Invoke();
    			
    			var prop = o.GetType().GetField("s");
    			prop.SetValue(o, "Hello from magic method call!");
                
                Trace.WriteLine(run.Body);
    			return default(T);
    		}
		
    [TestMethod]
    		public void TestExpressionInvocation()
    		{
    			var action = new MyActionObject();
    			
    			string s = null;
    			RunExpression(() => action.Create(1, out s));
    
    			Assert.AreEqual("Hello from magic method call!", s);
    		}
