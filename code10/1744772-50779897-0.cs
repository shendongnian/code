    public class IndexModel : PageModel
        private readonly AmazonSettings _amazonSettings;
        public string LoginUrl;
        public IndexModel(IOptions<AmazonSettings> amazonSettings)
        {
            _amazonSettings = amazonSettings.Value;
        }
