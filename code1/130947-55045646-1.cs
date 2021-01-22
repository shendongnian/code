	IReal //on which some extension method is defined
	{
		... SomeNotAnExtensionMethod(...);
	}
	ITest: IReal
	{
		... SomeExtensionMethod(...);
	}
	var someMock = new Mock<ITest>();
	Mock.As<IReal>(); //ad IReal to the mock
	someMock.Setup(x => x.SomeExtensionMethod()).Verifiable(); //Calls SomeExtensionMethod on ITest
	someMock.As<IReal>().Setup(x => x.SomeNotAnExtensionMethod()).Verifiable(); //Calls SomeNotAnExtensionMethod on IReal
