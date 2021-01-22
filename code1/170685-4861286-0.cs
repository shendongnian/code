                var resultingIQueryable = ( new List<string> () ).AsQueryable<string>().Where (i => i.Contains ("some")).Where (i => i.Contains ("second_some"));
                // the Queryable.Where is a MethodCallExpression
                var expressionOriginal = resultingIQueryable.Expression as MethodCallExpression;
                // there are multiple where calls, this makes it all a little bit more confusing.
                // The linq tree is built 'backwards'
                // the first parameter of the expression is a MethodCallExpression:
                // {System.Collections.Generic.List`1[System.String].Where(i => i.Contains("some"))}
                // the second parameter:
                // {i => i.Contains("second_some")}
                //
                // disecting the first parameter you will again find 2 parameters:
                // {System.Collections.Generic.List`1[System.String]} 
                // {i => i.Contains("some")}
