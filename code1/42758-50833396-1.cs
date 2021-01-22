    public static bool IsPhoto(string fileName)
        {
            var list = FileListExtensions.GetAllPhotosExtensions();
            var filename= fileName.ToLower();
            bool isThere = false;
            foreach(var item in list)
            {
                if (filename.EndsWith(item))
                {
                    isThere = true;
                    break;
                }
            }
            return isThere;     
        }
