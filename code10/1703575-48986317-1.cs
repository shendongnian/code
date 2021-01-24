	public void Some_unit_test() {
		//Arrange
		var stubCustomLoadRepository = MockRepository.GenerateStub<ICustomLoadRepository>();
		stubCustomLoadRepository.Stub(_ => _.SomeCustomLoadMethod()).Return("Some value");
		
		var classUnderTest = new ExcelHelper(stubCustomLoadRepository);
		
		//Act
		//...exercise class under test
		
		//Assert
		//...
	}
