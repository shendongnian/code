    [TestMethod]
    public async Task PostMethodWorks() {
        //Arrange
        var controller = new MyController();
    
        var data = "this will be JSON";
        var httpRequestMessage = new HttpRequestMessage();
        //set the content somehow so that httpRequestMessage.Content.ReadAsStringAsync returns data 
        httpRequestMessage.Content = new StringContent(data, Encoding.UTF8, "application/json");
        
    
        //Act
        var response = await controller.Post(httpRequestMessage);
    
        //Assert
        //assert something about the response here
    }
