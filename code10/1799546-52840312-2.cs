    [TestClass]
    public class CinemaFactoryTests
    {
        [TestMethod]
        public void GivenItemProps_WhenCreatingSpace_ShouldReturnExpectedSpace()
        {
            // arrange
            var factory = new CinemaFactory();
            var props = new AddItemsInProps
            {
                AreaType = "my area",
                Position = "my position",
                Dimension = "my dimension"
            };
            // act
            Space cinema = factory.createspace(props);
            // assert
            var expectedCinema = new Cinema(props.AreaType, props.Position, props.Dimension);
            cinema.Should().BeEquivalentTo(expectedCinema);
        }
    }
