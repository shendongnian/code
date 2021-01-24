    ParameterExpression pe = Expression.Parameter(typeof(int));
    
    SwitchExpression switchExpr =
    	Expression.Switch(
    		pe,
    		Expression.Call(
    					null,
    					typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
    					Expression.Constant("Default")
    				),
    		new SwitchCase[] {
    			Expression.SwitchCase(
    				Expression.Call(
    					null,
    					typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
    					Expression.Constant("First")
    				),
    				Expression.Constant(1)
    			),
    			Expression.SwitchCase(
    				Expression.Call(
    					null,
    					typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }),
    					Expression.Constant("Second")
    				),
    				Expression.Constant(2)
    			)
    		}
    	);
    
    var action = Expression.Lambda<Action<int>>(switchExpr,pe).Compile();
    action(1);
    action(2);
    action(3);
