    public class FileUploadViewModel
    {
        public IFormFile File { get; set; }
        public int BrandId { get; set; }
    }
    public async Task<BaseListResponse<MediaStorageModel>> MediaBrand([FromForm] FileUploadViewModel viewModel)
