       protected void ValidateFile(IFormFile file)
        {
            if (file == null)
                throw new Filters.ApiException(this.Localizer[string.Format(ErrorConst.SelectFile)].Value, 400);
            if (file.Length < 1)
                throw new Filters.ApiException(this.Localizer[string.Format(ErrorConst.ErrorImageSize)].Value, 400);
            int filesize = 3;
            string[] supportedTypes = new[] { "jpg", "jpeg", "png", "bmp" };
            var fileExt = System.IO.Path.GetExtension(file.FileName).Substring(1);
            if (!supportedTypes.Contains(fileExt))
                throw new Filters.ApiException(this.Localizer[ErrorConst.ErrorImageExtension].Value, 400);
            if (file.Length > (filesize * 1024 * 1024))
                throw new Filters.ApiException(this.Localizer[string.Format(ErrorConst.ErrorImageSize, filesize)].Value, 400);
        }
