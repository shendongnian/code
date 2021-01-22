        public static DirectoryInfo GetCreateMyFolder(string baseFolder)
        {
            var now = DateTime.Now;
            var yearName = now.ToString("yyyy");
            var monthName = now.ToString("MMMM");
            var dayName = now.ToString("dd-MM-yyyy");
            
            var folder = Path.Combine(baseFolder,
                           Path.Combine(yearName,
                             Path.Combine(monthName,
                               dayName)));
            if( !Directory.Exists(folder))
                Directory.CreateDirectory(folder);
            
            return new DirectoryInfo(folder);
        }
