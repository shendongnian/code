    [Fact]
    public async Task RequestIsVerifiable() {
    
        //Arrange
        var wcfMock = new Mock<IService>();
        
        var response = new EMCResponse {
            //populate
        };
    
        wcfMock
            .Setup(x => x.EMCreateAsync(It.IsAny<EMCreateRequest>()))
            .ReturnAsync(response);
    
        var peProcessor = new PEProcessor(wcfMock.Object);
    
        //Act        
        await peProcessor.CreateAddress(MoqData.ModelName, MoqData.version, MoqData.name,
            MoqData.MType, MoqData.AddressesList(), MoqData.EMRequest);
    
        //Assert
        wcfMock.Verify(service => service.EMCreateAsync(It.IsAny<EMCreateRequest>()), Times.AtLeastOnce);
    }
