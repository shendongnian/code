		[TestMethod]
		public void TestMethod2()
		{
			Mock<ISomeInterface> myMock = new Mock<ISomeInterface>();
			ImplementationClass myImplementationClass = new ImplementationClass(myMock.Object);
			string Arg1 = "Arg1";
			string Arg2 = "Arg2";
			myImplementationClass.Investigate(Arg1, Arg2);
			var methodInfo = typeof(ISomeInterface).GetMethod(nameof(ISomeInterface.DoSomething));
			var parameter = Expression.Parameter(typeof(ISomeInterface), "m");
			var call = Expression.Call(parameter, methodInfo, Expression.Constant(Arg1), Expression.Constant(Arg2));
			Expression<Action<ISomeInterface>> expression = Expression.Lambda<Action<ISomeInterface>>(call, parameter);
			myMock.Verify(expression);
		}
