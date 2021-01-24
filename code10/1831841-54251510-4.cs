    public class FileUploadController : Controller
    {
        private SomeDbContext db = new SomeDbContext();
        // This is the root folder where your files will be saved, you can store this in your web.config
        private const string FilesRoot = @"c:\temp";
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
