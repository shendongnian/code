    [TestClass]
    public class AutoFixtureDefaultGeneric {
        [TestMethod]
        public void AutoFixture_Should_Create_Generic_With_Default() {
            // Arrange
            Fixture fixture = new Fixture();
            fixture.Customizations.Add(new TypeRelay(typeof(IResult<>), typeof(FakeResult<>)));
            //Act
            var result = fixture.Create<IResult<string>>();
            //Assert
            result.Success.Should().BeTrue();
        }
    }
