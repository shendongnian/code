        public static void CopyDBToDownloadsDirectory()
        {
            var path = System.IO.Path.Combine(
                Android.OS.Environment.GetExternalStoragePublicDirectory(Android.OS.Environment.DirectoryDownloads).AbsolutePath,
                "backend.db3");
            string DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var safePath = Path.Combine(DocumentPath, "backend.db3");
            File.Copy(safePath, path, true);
        }
