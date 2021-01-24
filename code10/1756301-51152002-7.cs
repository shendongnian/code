      [Test]
      public void TestMethod1()
      {
          //Create a Mock
          var mockAnotherService = new Mock<IAnotherService>();
          //Set the property value when called.
          mockAnotherService.Setup(method => method.ValueForB).Returns(10);//Test 1
                
          var service1Consumer = new Service1Consumer(mockAnotherService.Object);
          var result = service1Consumer.GetData();
    
          Assert.AreEqual("XXXX",result);
    
       }
