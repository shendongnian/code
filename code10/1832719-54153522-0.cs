    public interface IJobOfferController
    {
        Task<string> UploadCvToAzureStorage(IFormFile file);
    }
    public class JobOfferController : IJobOfferController
    {
        public Task<string> UploadCvToAzureStorage(IFormFile file) => throw new NotImplementedException();
    }
