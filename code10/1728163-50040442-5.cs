	[Fact]
	public void Test_WhenSomethingIsTrue_MethodB_Invoked_WithObjects_B_And_C()
	{
		// Arrange
		Mock<ObjectImplementation> mockObject = new Mock<ObjectImplementation>();
		ObjectA arg = new ObjectA();
		arg.Something = true;
		// Act
		mockObject.Object.MethodA(arg);
		// Assert
		mockObject.Verify(o => o.MethodB(It.Is<ObjectB>(b=> b.Arg == arg), It.Is<ObjectC>(c => c.Arg == arg)));
	}
	[Fact]
	public void Test_WhenSomethingIsFalse_MethodC_Invoked_WithObjects_D_And_E()
	{
		// Arrange
		Mock<ObjectImplementation> mockObject = new Mock<ObjectImplementation>();
		ObjectA arg = new ObjectA();
		arg.Something = false;
		// Act
		mockObject.Object.MethodA(arg);
		// Assert
		mockObject.Verify(o => o.MethodC(It.Is<ObjectD>(d => d.Arg == arg), It.Is<ObjectE>(e => e.Arg == arg)));
	}
