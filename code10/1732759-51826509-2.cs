        [Authorize]
        public IActionResult SpaFallback()
        {
            var fileInfo = _env.ContentRootFileProvider.GetFileInfo("ClientApp/dist/index.html");
            using (var reader = new StreamReader(fileInfo.CreateReadStream()))
            {
                var fileContent = reader.ReadToEnd();
                var basePath = !string.IsNullOrWhiteSpace(Url.Content("~")) ? Url.Content("~") + "/" : "/";
                //Note: basePath needs to match request path, because cookie.path is case sensitive
                fileContent = Regex.Replace(fileContent, "<base.*", $"<base href=\"{basePath}\">");
                return Content(fileContent, "text/html");
            }
        }
