    [TestMethod()]
    public void getDataTest()
    {
         int a = 5, b = 9; // here
         int c = 14; // and here
         var mockService = new Mock<Interface1>();
         mockService.Setup(x => x.AddNumbers(a,b)).Returns(c);
    
         Class1 obj = new Class1(mockService.Object);
         var result = obj.getData();
         int final = result;
     } 
