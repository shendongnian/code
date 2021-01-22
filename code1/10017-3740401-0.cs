                DirectoryInfo di = null;
                List<string> FileList = new List<string>();
                di = new DirectoryInfo(@"C:\DirName\");
                IEnumerable<System.IO.FileInfo> fileList = di.GetFiles("*.*");
                
                //Create the query
                IEnumerable<System.IO.FileInfo> fileQuery =
                    from file in fileList
                    where (file.Extension.ToLower() == ".jpg" || file.Extension.ToLower() == ".png")
                    orderby file.LastWriteTime
                    select file;
                foreach (System.IO.FileInfo fi in fileQuery)
                {
                    fi.Attributes = FileAttributes.Normal;
                    FileList.Add(fi.FullName);
                }
