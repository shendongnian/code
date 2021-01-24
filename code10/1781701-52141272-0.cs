    [TestFixture]    
    public class Control { 
        
        [Test]    
        public void TestMethod1() {
            //Arrange
            var repository = new Mock<IRepository<GroupStructure>>();
            //...Set up the repository behavior to satisfy logic
            var uow = new Mock<IUnitOfWork>();
            uow.Setup(_ => _.GetRepository<AgencyGroupStructure>())
                .Returns(repository.Object);
              
            var sut = new ControlService(uow.Object);
            var expected = true;
            //Act
            var actual = sut.HasExternalImage(1249);
            //Assert
            Assert.AreEqual(actual.Item1, expected);    
        }    
    }
