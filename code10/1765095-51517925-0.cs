       public async Task<byte[]> BuildFile(ActionContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            //if (this.WkhtmlPath == string.Empty)
            //    this.WkhtmlPath = context.HttpContext.Server.MapPath("~/Rotativa");
            this.WkhtmlPath = RotativaConfiguration.RotativaPath;
            var fileContent = await CallTheDriver(context);
            if (string.IsNullOrEmpty(this.SaveOnServerPath) == false)
            {
                File.WriteAllBytes(this.SaveOnServerPath, fileContent);
            }
            return fileContent;
        }
