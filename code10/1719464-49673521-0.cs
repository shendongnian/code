        [Fact]
        public void Test()
        {
            // Arrange
            Mock<A> mockA = new Mock<A>();
            int count = 0;
            mockA.Setup(x => x.M1()).Returns(true).Callback(() => { count++; });
            mockA.Setup(x => x.M2());
            // Act
            B b = new B(mockA.Object);
            b.Mb();
            // Assert
            mockA.Verify(m => m.M2(), Times.Exactly(count), "all exactly time that M1 returned false");
        }
