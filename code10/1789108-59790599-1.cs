    public async Task UploadBrandImage()
    {
        var uploadDir = Path.Combine(_hostingEnvironment.WebRootPath, "images/vehicle-icons");
        //If folder of new key is not exist, create the folder.
        if (!Directory.Exists(uploadDir)) Directory.CreateDirectory(uploadDir);
        foreach (var contentFile in Request.Form.Files)
        {
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images/vehicle-icons", contentFile.FileName);
            if (contentFile.Length <= 0) continue;
            // Using like this will not work
            //await contentFile.CopyToAsync(new FileStream($"{uploadDir}\\{contentFile.FileName}", FileMode.Create));
            using (var fileSteam = new FileStream(filePath, FileMode.Create))
            {
                await contentFile.CopyToAsync(fileSteam);
            }
        }
    }
