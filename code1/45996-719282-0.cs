using System;
using System.Linq;
using System.Diagnostics;
using System.Reflection;
using System.Linq.Expressions;
class Program
{
    static void Create(object o, int n) { Debug.Print("Create!"); }
    static void LookAtThis(Expression<Action> expression)
    {
        //inspect:
        MethodInfo method = ((MethodCallExpression)expression.Body).Method;
        Debug.Print("Method = '{0}'", method.Name);
        //execute:
        Action action = expression.Compile();
        action();
    }
    static void Main(string[] args)
    {
        LookAtThis((Expression<Action>)(() => Create(null, 0)));
    }
}
</pre>
