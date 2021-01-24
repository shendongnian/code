        [Test]
        public void SendOrderTest()
        {
            //Arrange
            Mock<IDALPerson> MockDAL = new Mock<IDALPerson>();
            Person p = new Person(MockDAL);         
            
            //Act
            p.SendOrder();
            //Assert
            //Assert something.
       }
