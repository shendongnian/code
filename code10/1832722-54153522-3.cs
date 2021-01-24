    public void SetUp()
    {
        //this is trying to mock the concrete class and will fail
        var controller = new Mock<JobOfferController>(context);            
        controller.Setup(m => m.UploadCvToAzureStorage(It.IsAny<IFormFile>()))
            .Returns(Task.FromResult("cv-url"));
        //This Mocks the interface and sets up a return value for that interface
        var mockController = new Mock<IJobOfferController>();
        mockController.Setup(m => m.UploadCvToAzureStorage(It.IsAny<IFormFile>()))
            .Returns(Task.FromResult("cv-url"));
    }
