    [TestClass]
    public class MyTestClass {
        [Test]
        public void _DoThing_Should_Be_Invoked() {
            //Arrange            
            var parameter = "ABC";
            var mock = new Mock<IToBeMocked>();
            mock
                .Setup(m => m.DoThing(It.IsAny<IParameter>()));
            //Act
            new Processor(mock.Object).Process(parameter);
            //Assert            
            mock.Verify(m => m.DoThing(It.IsAny<IParameter>()), Times.Once);
        }
        [Test]
        public void _Parameter_Should_Not_Be_Null() {
            //Arrange
            IParameter actual = null;
            var parameter = "ABC";
            var mock = new Mock<IToBeMocked>();
            mock
                .Setup(m => m.DoThing(It.IsAny<IParameter>()))
                .Callback<IParameter>(p => actual = p);
            //Act
            new Processor(mock.Object).Process(parameter);
            //Assert
            actual.Should().NotBeNull();
            mock.Verify(m => m.DoThing(It.IsAny<IParameter>()), Times.Once);
        }
        [Test]
        public async Task _Parameter_Content_Should_Be_Expected() {
            //Arrange
            
            IParameter parameter = null;
            var expected = "ABC";
            var mock = new Mock<IToBeMocked>();
            mock
                .Setup(m => m.DoThing(It.IsAny<IParameter>()))
                .Callback<IParameter>(p => parameter = p);
            new Processor(mock.Object).Process(expected);
            parameter.Should().NotBeNull();
            //Act
            var actual = await parameter.Content;
            //Assert
            actual.Should().Be(expected);
            mock.Verify(m => m.DoThing(It.IsAny<IParameter>()), Times.Once);
        }
    }
