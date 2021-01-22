        [HttpGet]
        public FileResult DownloadFile(int? fileId)
        {
            FilesEntities entities = new FilesEntities();
            Video video = entities.Videos.ToList().Find(p => p.id == fileId.Value);
            return File(video.Data, video.ContentType, video.Name);
        }
