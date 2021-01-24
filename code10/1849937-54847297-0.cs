    using System;
	using System.Collections.Generic;
	public class Expression{}
	public class Value{}
	public class Token{}
	public class Cube{}
	public class Result{
		public int result = 11;
	}
	
	namespace MyNameSpace{
		using MyGenericFunc = Func<Expression, Dictionary<string, string>, Dictionary<string, Value>, Dictionary<string, Token>, Dictionary<string, Cube>, Result>;
		public class Program
		{
			public static void Main()
			{
				Expression expression = new Expression();
				Dictionary<string, string> env = new Dictionary<string, string>(); 
				Dictionary<string, Value> store = new Dictionary<string, Value>();
				Dictionary<string, Token> tokenEnv = new Dictionary<string, Token>();
				Dictionary<string, Cube> cubeEnv = new Dictionary<string, Cube>();
				// normal call
				Console.WriteLine("When calling the method directly: " + ToStringFunc(expression, env, store, tokenEnv, cubeEnv).result);
				// call via func and dictionary
				MyGenericFunc retrievedFunc;
				builtInFunctions.TryGetValue("ToString", out retrievedFunc);
				Console.WriteLine("When calling the method retrieved from dictionary: " + retrievedFunc.Invoke(expression, env, store, tokenEnv, cubeEnv).result);
			}
			static Dictionary<string, MyGenericFunc> builtInFunctions = new Dictionary<string, MyGenericFunc>()
			{
				{"ToString", ToStringFunc}
			};
			static Result ToStringFunc(
				Expression expression,
				Dictionary<string, string> env, 
				Dictionary<string, Value> store, 
				Dictionary<string, Token> tokenEnv, 
				Dictionary<string, Cube> cubeEnv
			) {
				return new Result();
			}
		}
	}
	
	
