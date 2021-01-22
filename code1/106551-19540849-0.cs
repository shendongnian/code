        [TestMethod]
        public void CallInOrder()
        {
            // Arrange
            string callOrder = "";
            
            var service = new Mock<MyService>();
            service.Setup(p=>p.FirstCall()).Returns(0).CallBack(p=>callOrder += "1");
            service.Setup(p=>p.SecondCall()).Returns(0).CallBack(p=>callOrder += "2");
            
            var sut = new Client(service);
            // Act
            sut.DoStuff();
            
            // Assert
            Assert.AreEqual("12", callOrder);
        }
