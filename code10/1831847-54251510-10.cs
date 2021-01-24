    public class FileUploadController : Controller
    {
        private SomeDbContext db = new SomeDbContext();
        // You should store the following settings in your Web.config or in your DB, I just put them here for demo purposes
        // This is the root folder where your files will be saved
        private string FilesRoot = @"c:\temp";
        // Accepted file types and maximum size, for security (it should match the settings in your view)
        private string[] AcceptedFiles = new string[] { ".jpg", ".png", ".doc" };
        private int MaxFileSizeMB = 10;
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult UploadFiles(int customerId)
        {
            if (Request.Files.Count == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            foreach(string file in Request.Files)
            {
                var upload = Request.Files[file];
                if (!ValidateUpload(upload))
                    return new HttpStatusCodeResult(HttpStatusCode.Forbidden);
                string filename = Guid.NewGuid().ToString() + Path.GetExtension(upload.FileName);
                // Save the file in FilesRoot/{CustomerId}/{GUID}
                string savePath = Path.Combine(FilesRoot, customerId.ToString());
                if (!Directory.Exists(savePath))
                {
                    Directory.CreateDirectory(savePath);
                }
                upload.SaveAs(Path.Combine(savePath, filename));
                // Save file to database
                var fileUpload = new FileUploadModel()
                {
                    CustomerId = customerId,
                    Filename = filename,
                    OriginalFilename = upload.FileName,
                    ContentType = upload.ContentType
                };
                db.FileUploads.Add(fileUpload);
                db.SaveChanges();
            }
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
        private bool ValidateUpload(HttpPostedFileBase upload)
        {
            if (!AcceptedFiles.Contains(Path.GetExtension(upload.FileName)))
                return false;
            else if (upload.ContentLength > MaxFileSizeMB * 1048576)
                return false;
            return true;
        }
        public ActionResult DownloadFile(int id)
        {
            var fileUpload = db.FileUploads.FirstOrDefault(x => x.Id == id);
            if (fileUpload == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            string path = Path.Combine(FilesRoot, fileUpload.CustomerId.ToString(), fileUpload.Filename);
            byte[] fileContents = System.IO.File.ReadAllBytes(path);
            return File(fileContents, fileUpload.ContentType, fileUpload.OriginalFilename);
        }
        public ActionResult ListFiles(int customerId)
        {
            var files = db.FileUploads.Where(x => x.CustomerId == customerId);
            return View(files.ToList());
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
