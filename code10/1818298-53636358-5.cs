    public class ExcelServiceTests {
        [Fact]
        public async Task GetData_WhenCalled() {
            //Arrange
            var stream = File.OpenRead(@"C:\myfile.xlsx");
            var service = new ExcelService();
            
            //Act
            var actual = await service.GetDataAsync(stream);
            
            //Assert
            //...assert the contents of actual data.
        }
    }
    
