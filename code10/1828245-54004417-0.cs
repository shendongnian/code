      internal class ImageExtractor : IRenderListener
    {
        private int _currentPage = 1;
        private int _imageCount = 0;
        private readonly string _outputFilePrefix;
        private readonly string _outputFolder;
        private readonly bool _overwriteExistingFiles;
        private ImageExtractor(string outputFilePrefix, string outputFolder, bool overwriteExistingFiles)
        {
            _outputFilePrefix = outputFilePrefix;
            _outputFolder = outputFolder;
            _overwriteExistingFiles = overwriteExistingFiles;
        }
        /// <summary>
        /// Extract all images from a PDF file
        /// </summary>
        /// <param name="pdfPath">Full path and file name of PDF file</param>
        /// <param name="outputFilePrefix">Basic name of exported files. If null then uses same name as PDF file.</param>
        /// <param name="outputFolder">Where to save images. If null or empty then uses same folder as PDF file.</param>
        /// <param name="overwriteExistingFiles">True to overwrite existing image files, false to skip past them</param>
        /// <returns>Count of number of images extracted.</returns>
        public static int ExtractImagesFromFile(string pdfPath, string outputFilePrefix, string outputFolder, bool overwriteExistingFiles)
        {
            // Handle setting of any default values
            outputFilePrefix = outputFilePrefix ?? System.IO.Path.GetFileNameWithoutExtension(pdfPath);
            outputFolder = String.IsNullOrEmpty(outputFolder) ? System.IO.Path.GetDirectoryName(pdfPath) : outputFolder;
            var instance = new ImageExtractor(outputFilePrefix, outputFolder, overwriteExistingFiles);
            using (var pdfReader = new PdfReader(pdfPath))
            {
                if (pdfReader.IsEncrypted())
                    throw new ApplicationException(pdfPath + " is encrypted.");
                var pdfParser = new PdfReaderContentParser(pdfReader);
                while (instance._currentPage <= pdfReader.NumberOfPages)
                {
                    pdfParser.ProcessContent(instance._currentPage, instance);
                    instance._currentPage++;
                }
            }
            return instance._imageCount;
        }
        #region Implementation of IRenderListener
        public void BeginTextBlock() { }
        public void EndTextBlock() { }
        public void RenderText(TextRenderInfo renderInfo) { }
        public void RenderImage(ImageRenderInfo renderInfo)
        {
            if (_imageCount == 0)
            {
                var imageObject = renderInfo.GetImage();
                var imageFileName = _outputFilePrefix + _imageCount; //to get multiple file (you should add .jpg or .png ...)
                var imagePath = System.IO.Path.Combine(_outputFolder, imageFileName);
                if (_overwriteExistingFiles || !File.Exists(imagePath))
                {
                    var imageRawBytes = imageObject.GetImageAsBytes();
                    //create a new file ()
					File.WriteAllBytes(imagePath, imageRawBytes);
                }
            }
            _imageCount++;
        }
       
        #endregion // Implementation of IRenderListener
    }
