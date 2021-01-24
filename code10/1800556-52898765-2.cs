    public class ValuesControllerTests
        {
            private Mock<IDynamoDbManager<MyModel>> _dbManager;
            private ValuesController _valuesController;
    
            public ValuesControllerTests()
            {
                var mockRepository = new MockRepository(MockBehavior.Loose);
                _dbManager = mockRepository.Create<IDynamoDbManager<MyModel>>();
                var options = new OptionsWrapper<Dictionary<string, string>>(new Dictionary<string, string>()
                {
                    {"dynamoDbTable", nameof(MyModel) }
                });
                _valuesController = new ValuesController(options, _dbManager.Object);
                
            }
    
            [Fact]
            public async Task GetAllData_ShouldSelectUpdateByInLowerCase()
            {
                //
                var searchResult = new List<MyModel>()
                {
                    new MyModel() {UpdatedBy = "UpdatedBy1"}
                };
                _dbManager
                    .Setup(_ => _.Get(It.Is<List<ScanCondition>>(list => list.Count == 2)))
                    .ReturnsAsync(searchResult);
    
                //
    
                var result = await _valuesController.GetAllData("typeValue", "statusValue");
    
                //
                var okResult = result as OkObjectResult;
                Assert.NotNull(okResult);
                var values = okResult.Value as List<string>;
                Assert.Contains("updatedby1", values);
            }
    
            [Fact]
            public async Task SaveData_ShouldCallSaveForAllRequestedData()
            {
                //
                var listData = new List<MyModel>()
                {
                    new MyModel(),
                    new MyModel(),
                    new MyModel()
                };
                _dbManager
                    .Setup(_ => _.SaveAsync(It.IsAny<MyModel>()))
                    .Returns(Task.CompletedTask);
    
                //
    
                var result = await _valuesController.SaveData(listData, "","", "");
    
                //
                _dbManager.Verify(_ => _.SaveAsync(It.IsAny<MyModel>()), Times.Exactly(3));
            }
        }
