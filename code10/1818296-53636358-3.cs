    public class MyController : Controller {
        private readonly IExcelService excel;
        public MyController(IExcelService excel) {
            this.excel = excel;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> UploadFile(IFormFile file) {
            JArray data = await excel.GetDataAsync(myFile.OpenReadStream());
            return Ok(data);
        }
    }
    
