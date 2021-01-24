    [TestFixture]
	public class BindModelAsyncTest()
	{
		private JourneyTypesModelBinder _modelBinder;
		private Mock<ModelBindingContext> _mockedContext;
		
		// Setting up things
		public BindModelAsyncTest()
		{
			_modelBinder = new JourneyTypesModelBinder();
			_mockedContext = new Mock<ModelBindingContext>();
			
			_mockedContext.Setup(c => c.ValueProvider)
				.Returns(new ValueProvider() 
                {
                    // Initialize values that are used in this function
                });
		}
						 
		private JourneyTypesModelBinder CreateService => new JourneyTypesModelBinder();
		
		[Test]						 
		public Task BindModelAsync_Unittest()
		{
			//Arrange
			//We set variables in setup fucntion.
			var unitUnderTest = CreateService();
			
			//Act
			var result = unitUderTest.BindModelAsync(_mockedContext);
			
			//Assert
			Assert.IsNotNull(result);
			Assert.IsTrue(result is Task.CompletedTask);
		}
	} 
