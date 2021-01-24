    [TestClass]
    public class CinemaFactorTests {
        [TestMethod]
        public void CinemaFactory_Should_Create_Cinema() {
            //Arrange
            var cinemaFactory = new Game1.Design_Patterns.CinemaFactory();
        
            var item = new AddItemsInProps {
                //set necessary properties here
            };
            //Act
            var actual = cinemaFactory.createspace(item);
        
            //Assert
            Assert.IsNotNull(actual);
            //...you can also compare property values from item and actual for equality
            Assert.AreEqual(item.AreaType, actual.AreaType);
            //...
        }
    }
