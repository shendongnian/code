    [TestClass]
    public class ViewModelTests {
        private Mock<IGetService> GetServiceMock{ get; set; }
        private ViewModel ViewModel { get; set; }
        [TestInitialize()]
        public void Initialize()
        {
            GetServiceMock= new Mock<IGetService>();
            ViewModel = new ViewModel (GetServiceMock.Object);
        }
        [TestMethod()]
        public void GetResultTests() {
            // Arrange
            var expectedFirstName = "FirstName";
            var expectedLastName = "LastName";
            var expectedInput = "Input";
            var expectedOutput = "Output";
            var expectedResult = "FirstName LastName,Output";
            
            //set properties on view model
            ViewModel.FirstName = expectedFirstName;
            ViewModel.LastName = expectedLastName;
            ViewModel.Input = expectedInput;
            
            //Arrange mock to expect specific model
            GetServiceMock
                .Setup(_ =>  _.GetOutput(It.Is<PersonModel>(p=> 
                    p.FirstName == expectedFirstName &&
                    p.LastName == expectedLastName &&
                    p.Input == expectedInput
                )))
                .Callback((PersonModel p) => { // <-- use callback to set Output on model
                    p.Output = expectedOutput;
                });
            // Act
            ViewModel.ResultFromModelToView();
            actualResult = ViewModel.Result;
            
            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
