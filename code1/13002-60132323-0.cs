    public class ImageValidator
    {
        private readonly Dictionary<string,byte[]> _validBytes = new Dictionary<string, byte[]>() {
            { ".bmp", new byte[] { 66, 77 } },
            { ".gif", new byte[] { 71, 73, 70, 56 } },
            { ".ico", new byte[] { 0, 0, 1, 0 } },
            { ".jpg", new byte[] { 255, 216, 255 } },
            { ".png", new byte[] { 137, 80, 78, 71, 13, 10, 26, 10, 0, 0, 0, 13, 73, 72, 68, 82 } },
            { ".tiff", new byte[] { 73, 73, 42, 0 } },
        };
        /// <summary>
        /// image formats to validate using Guids from ImageFormat.
        /// </summary>
        private readonly Dictionary<Guid, string> _validGuids = new Dictionary<Guid, string>() {
            {ImageFormat.Jpeg.Guid, ".jpg" },
            {ImageFormat.Png.Guid, ".png"},
            {ImageFormat.Bmp.Guid, ".bmp"},
            {ImageFormat.Gif.Guid, ".gif"},
            {ImageFormat.Tiff.Guid, ".tiff"},
            {ImageFormat.Icon.Guid, ".ico" }
        };
        /// <summary>
        /// Supported extensions: .jpg,.png,.bmp,.gif,.tiff,.ico
        /// </summary>
        /// <param name="allowedExtensions"></param>
        public ImageValidator(string allowedExtensions = ".jpg;.png")
        {
            var exts = allowedExtensions.Split(';');
            foreach (var pair in _validGuids.ToArray())
            {
                if (!exts.Contains(pair.Value))
                {
                    _validGuids.Remove(pair.Key);
                }
            }
            foreach (var pair in _validBytes.ToArray())
            {
                if (!exts.Contains(pair.Key))
                {
                    _validBytes.Remove(pair.Key);
                }
            }
        }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0063:Use simple 'using' statement", Justification = "<Pending>")]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1031:Do not catch general exception types", Justification = "<Pending>")]
        public async Task<bool> IsValidAsync(Stream imageStream, string filePath)
        {
            if(imageStream == null || imageStream.Length == 0)
            {
                return false;
            }
            //First validate using file extension
            string ext = Path.GetExtension(filePath).ToLower();
            if(!_validGuids.ContainsValue(ext))
            {
                return false;
            }
            //Check mimetype by content
            if(!await IsImageBySigAsync(imageStream, ext))
            {
                return false;
            }
            try
            {
                //Validate file using Guid.
                using (var image = Image.FromStream(imageStream))
                {
                    imageStream.Position = 0;
                    var imgGuid = image.RawFormat.Guid;
                    if (!_validGuids.ContainsKey(imgGuid))
                    {
                        return false;
                    }
                    var validExtension = _validGuids[imgGuid];
                    if (validExtension != ext)
                    {
                        return false;
                    }
                }
            }
            catch (OutOfMemoryException)
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// Validate the mimetype using byte and file extension.
        /// </summary>
        /// <param name="imageStream"></param>
        /// <param name="extension"></param>
        /// <returns></returns>
        private async Task<bool> IsImageBySigAsync(Stream imageStream, string extension)
        {
            var length = _validBytes.Max(x => x.Value.Length);
            byte[] imgByte = new byte[length];
            await imageStream.ReadAsync(imgByte, 0, length);
            imageStream.Position = 0;
            if (_validBytes.ContainsKey(extension))
            {
                var validImgByte = _validBytes[extension];
                if (imgByte.Take(validImgByte.Length).SequenceEqual(validImgByte))
                {
                    return true;
                }
            }
            return false;
        }
    }
