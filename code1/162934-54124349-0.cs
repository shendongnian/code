	// MyFancyClassTests.cs
	namespace MyTests
	{
		using Microsoft.VisualStudio.TestTools.UnitTesting;
		[TestClass]
		public class MyFancyClassTest
		{
			private readonly MyFancyClass _MyFancyClass;
			public MyFancyClassTest()
			{
				_MyFancyClass= new MyFancyClass();
			}
			[TestMethod]
			public void MyFancyClass_UninitializedName_ReturnsEmptyString()
			{
				Assert.AreEqual(string.Empty, _MyFancyClass.Name);
			}
		}
	}
