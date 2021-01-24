    public class JobOfferController : IJobOfferController
    {
        public virtual Task<string> UploadCvToAzureStorage(IFormFile file) => throw new NotImplementedException();
    }
    //now the setup works
    var controller = new Mock<JobOfferController>(context);            
    controller.Setup(m => m.UploadCvToAzureStorage(It.IsAny<IFormFile>()))
        .ReturnsAsync("cv-url");
