    //Interface to the ocr page identifier, you would create a enum for the document types
    public interface IPageIdentifier
    {
        Rectangle Focus { get; set; }
        DocumentTypeEnum? Identify(Byte[] page);
    }
     public abstract class OcrPageIdentifier : IPageIdentifier, IDisposable
    {
        protected abstract DocumentTypeEnum? IdentifyDocument(IEnumerable<string> words);
        private Tesseract _ocr;
        protected OcrPageIdentifier()
        {
            _ocr = new Tesseract();
            _ocr.Init(GetDictionaryDirectory(), "eng", false);
        }
        private static string GetDictionaryDirectory()
        {
            string path = HttpContext.Current != null ?
                HttpContext.Current.Server.MapPath(HttpContext.Current.Request.ApplicationPath + "/bin/") :
                Environment.CurrentDirectory;
            CheckDictionaryFiles(path);
            return path;
        }
        private static void CheckDictionaryFiles(string path)
        {
            if (!path.EndsWith(@"\"))
                path += @"\";
            if (!(File.Exists(path + "eng.DangAmbigs") &
                  File.Exists(path + "eng.freq-dawg") &
                  File.Exists(path + "eng.inttemp") &
                  File.Exists(path + "eng.normproto") &
                  File.Exists(path + "eng.pffmtable") &
                  File.Exists(path + "eng.unicharset") &
                  File.Exists(path + "eng.user-words") &
                  File.Exists(path + "eng.word-dawg")))
                throw new FileNotFoundException("Dictionary files not found");
        }
        private Rectangle _focus = Rectangle.Empty;
        public Rectangle Focus
        {
            get { return _focus; }
            set { _focus = value; }
        }
        public DocumentTypeEnum? Identify(byte[] page)
        {
            using (var ms = new MemoryStream(page))
            {
                using (var bitmap = new Bitmap(ms))
                {
                    //Ocr at current rotation.
                    DocumentTypeEnum? docType = GetDocType(bitmap);
                    if (docType != null)
                    {
                        return docType;
                    }
                    //Ocr rotated -90 
                    docType = GetDocType(RotateImage(bitmap, -90f));
                    if (docType != null)
                    {
                        return docType;
                    }
                    
                    //Ocr rotated 90
                    docType = GetDocType(RotateImage(bitmap, 90f));
                    if (docType != null)
                    {
                        return docType;
                    }
                    
                }
            }
            return null;
        }
        private DocumentTypeEnum? GetDocType(Bitmap bitmap)
        {
            List<Word> ocrResults = _ocr.DoOCR(bitmap, Focus);
            var words = ocrResults.Select(w => w.Text.ToLower()); 
            return IdentifyDocument(words);
        }
        public static Bitmap RotateImage(Image img, float rotationAngle)
        {
            //create an empty Bitmap image
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            //turn the Bitmap into a Graphics object
            Graphics gfx = Graphics.FromImage(bmp);
            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);
            gfx.RotateTransform(rotationAngle);
            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);
            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gfx.DrawImage(img, new Point(0, 0));
            //dispose of our Graphics object
            gfx.Dispose();
            //return the image
            return bmp;
        }
        public void Dispose()
        {
            _ocr.Clear();
            _ocr.Dispose();
            _ocr = null;
        }
    }
