    namespace myProject.Tests
    {
        [TestClass]
        public class SeriesTests
        {
            [TestMethod]
            public void Meaningful_Test_Name()
            {
                // Arrange
                SeriesProcessor processor = new SeriesProcessor(new FakeRepository());
    
                // Act
                IQueryable<Series> currentSeries = processor.GetCurrentSeries();
    
                // Assert
                Assert.AreEqual(currentSeries.Count(), 10);
            }
    
        }
    }
