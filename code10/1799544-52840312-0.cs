    [TestFixture]
    public class CinemaFactoryTests
    {
        [Test]
        [TestCase("area type", "some position", "some dimension")]
        public void GivenItemProps_WhenCreatingSpace_ShouldReturnExpectedSpace(
            string areaType, 
            string position, 
            string dimension
        )
        {
            // arrange
            var factory = new Game1.Design_Patterns.CinemaFactory();
            var props = new AddItemsInProps
            {
                AreaType = areaType,
                Position = position,
                Dimension = dimension
            };
            // act
            Space cinema = factory.createspace(props);
            // assert
            var expectedCinema = new Cinema(areaType, position, dimension);
            cinema.Should().BeEquivalentTo(expectedCinema);
        }
    }
