    public ActionResult Index()
        {
            List<Playlist_Contents_MVC> model = new List<Playlist_Contents_MVC>();
            model.Add(new Playlist_Contents_MVC() { DateAdded = DateTime.Now, HeaderId = 1, Id = 1, SongId = 1, SongFilePath = "/mp3FolderOnServer/1.mp3" });
            model.Add(new Playlist_Contents_MVC() { DateAdded = DateTime.Now, HeaderId = 2, Id = 2, SongId = 2, SongFilePath = "/mp3FolderOnServer/2.mp3" });
            model.Add(new Playlist_Contents_MVC() { DateAdded = DateTime.Now, HeaderId = 3, Id = 3, SongId = 3, SongFilePath = "/mp3FolderOnServer/3.mp3" });
            model.Add(new Playlist_Contents_MVC() { DateAdded = DateTime.Now, HeaderId = 4, Id = 4, SongId = 4, SongFilePath = "/mp3FolderOnServer/4.mp3" });
            model.Add(new Playlist_Contents_MVC() { DateAdded = DateTime.Now, HeaderId = 5, Id = 5, SongId = 5, SongFilePath = "/mp3FolderOnServer/5.mp3" });
            return View(model);
        }
