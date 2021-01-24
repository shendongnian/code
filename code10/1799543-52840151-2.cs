    [TestClass]
    public class CinemaFactorTests {
        [TestMethod]
        public void CinemaFactory_Should_Create_Cinema() {
            //Arrange
            var cinemaFactory = new Game1.Design_Patterns.CinemaFactory();
        
            var item = new AddItemsInProps {
                //set necessary properties here
                AreaType = "value here",
                Position = "value here",
                Dimension = "value here"
            };
            //Act
            var actual = cinemaFactory.createspace(item);
        
            //Assert
            Assert.IsNotNull(actual);
            Assert.IsInstanceOfType(actual, typeof(Cinema));
            //...you can also compare property values from item and actual for equality
            Assert.AreEqual(item.AreaType, actual.AreaType);
            //...
        }
    }
