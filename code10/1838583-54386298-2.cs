    public class ValuesController : ControllerBase
    {
        readonly IApplicationData _applicationData;
        public ValuesController(IApplicationData applicationData)
        {
            _applicationData = applicationData;
        }
        [HttpGet]
        public IActionResult Get()
        {
            string data = _applicationData.ProductMainPictureFolder;
            string data2 = _applicationData.GetProductPicturePath();
            string data3 = _applicationData.GetNewPath();
            return Ok();
        }
    }
