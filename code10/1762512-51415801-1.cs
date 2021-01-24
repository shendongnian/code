        public static bool DBExists()
        {
            string DocumentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(DocumentPath, "backend.db3");
            return File.Exists(path);
        }
