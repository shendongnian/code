        public static DirectoryInfo Subdirectory(this DirectoryInfo self, params string[] subdirectoryName)
        {
            Array.ForEach(
                subdirectoryName, 
                sn => self = new DirectoryInfo(Path.Combine(self.FullName, sn))
                );
            return self;
        }
