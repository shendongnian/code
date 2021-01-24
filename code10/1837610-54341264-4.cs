    public class MyApiController : ControllerBase {
        private readonly IHostingEnvirounment _hostingEnvirounment;
        public MyApiController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        // get image from project root folder \ProjectFolder\
        public Image GetImageFromContentRoot(string name) {
            // e.g.: imgPath = "D:\\Hosting\\ProjectFolder\\beep.png"
            var imgPath = Path.Combine(_hostingEnvirounment.ContentRootPath, name);
            return Image.FromFile(imgPath);
        }
        //get image from projects wwwroot folder
         public Image GetImageFromWebRoot(string name) {
            // e.g.: imgPath = "D:\\Hosting\\ProjectFolder\\wwwroot\\beep.png"
            var imgPath = Path.Combine(_hostingEnvirounment.WebRootPath, name);
            return Image.FromFile(imgPath);
        }
    }
