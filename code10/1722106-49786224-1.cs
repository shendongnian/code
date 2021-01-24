    [TestClass]
    public class RecursiveMocksTests {
        [TestMethod]
        public void Foo_Should_Recursive_Mock() {
            //Arrange
            IEnumerable<MyType> expected = Enumerable.Empty<MyType>();
            var mock = new Mock<IFoo>();
            // auto-mocking hierarchies (a.k.a. recursive mocks)
            mock.Setup(_ => _.TheProperty.GetTheValues()).Returns(expected);
            var mockedObject = mock.Object;
            //Act
            IEnumerable<MyType> actual = mockedObject.TheProperty.GetTheValues();
            //Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
