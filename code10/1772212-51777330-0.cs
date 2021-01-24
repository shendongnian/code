    using System;
	using System.Collections.Generic;
	using System.Diagnostics;
	using System.Linq.Expressions;
	using System.Reflection.Emit;
	using System.Threading.Tasks;
	using static System.Linq.Expressions.Expression;
	namespace ExpressionTests
	{
	    class Program
	    {
	        static async Task Main(string[] args)
	        {
		        Console.WriteLine(GetSyncAddExpression()(5) == 6);
		        Console.ReadKey();
				Console.WriteLine(await GetTaskAddExpression()(5) == 6);
		        Console.ReadKey();
	        }
		    private static Func<int, Task<int>> GetTaskAddExpression()
		    {
			    var fromResultMethod = typeof(Task).GetMethod(nameof(Task.FromResult)).MakeGenericMethod(typeof(int));
				var inParam = Parameter(typeof(int), "p1");
			    var assignmentValue = Variable(typeof(int), "assignVal");
			    var retVal = Variable(typeof(Task<int>));
				
			    var lambda = Lambda<Func<int, Task<int>>>(Block(
				    new[] { assignmentValue, retVal },
					Assign(assignmentValue, Add(inParam, Constant(1))),
					Assign(retVal, Call(null, fromResultMethod, assignmentValue)),
					retVal
				), inParam);
			    if (Debugger.IsAttached)
				    Debugger.Break();
				return lambda.Compile();
		    }
		    private static Func<int, int> GetSyncAddExpression()
		    {
				var inParam = Parameter(typeof(int), "p1");
			    var assignmentValue = Variable(typeof(int), "assignVal");
			    var retVal = Variable(typeof(int));
				
			    var lambda = Lambda<Func<int, int>>(Block(
					new[] {assignmentValue, retVal},
					Assign(assignmentValue, Add(inParam, Constant(1))),
					Assign(retVal, assignmentValue),
					retVal
				), inParam);
			    if (Debugger.IsAttached)
				    Debugger.Break();
				return lambda.Compile();
		    }
	    }
	}
