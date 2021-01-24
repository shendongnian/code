    var mock = new Mock<IKoopServiceRequestHelper>();
    mock.Setup(m => m.CreateRequestAsync(It.IsAny<ServiceRequestDTO>()))
    	.Returns(Task.FromResult(new ServiceResponseDTO()));
    mock.Setup(m => m.SendServiceMessagesAsync<ServiceRequestDTO, ServiceResponseDTO>(It.IsAny<ServiceRequestDTO>(), It.IsAny<string>()))
    	.Returns(Task.FromResult(new ServiceResponseDTO()));
