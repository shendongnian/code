        public void GetAllDirectoriesAndFiles(string getFolder, string putFolder)
        {
            List<string> dirIitems = DirectoryListing(getFolder);
            foreach (var item in dirIitems)
            {
                if ( File.Exists(getFolder + item) )
                {
                    GetFile(getFolder + item, putFolder + item);
                }
                else
                {
                    var subDirPut = new DirectoryInfo(putFolder + "\\" + item);
                    subDirPut.Create();
                    GetAllDirectoriesAndFiles(getFolder + item + "\\", subDirPut.FullName + "\\");
                }
            }
        }
