    public FileResult ImageDownload(int id)
        {
            var image = context.Images.Find(id);
            var imgPath = Server.MapPath(image.FilePath);
            return File(imgPath, "image/jpeg", image.FileName);
        }
