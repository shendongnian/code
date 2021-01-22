MethodCallExpression methodCallExpression = (MethodCallExpression)expression.Body;
MemberExpression memberExpression = (MemberExpression)methodCallExpression.Object;
Expression&lt;Func&lt;Object&gt;&gt; getCallerExpression = Expression&lt;Func&lt;Object&gt;&gt;.Lambda&lt;Func&lt;Object&gt;&gt;(memberExpression);
Func&lt;Object&gt; getCaller = getCallerExpression.Compile();
MyClass caller = (MyClass)getCaller();
