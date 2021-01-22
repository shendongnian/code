            System.IO.DirectoryInfo root = new System.IO.DirectoryInfo(rootPath);
            List<System.IO.FileInfo> xmlFiles=new List<System.IO.FileInfo>();
            foreach (System.IO.DirectoryInfo subDir1 in root.GetDirectories())
            {
                foreach (System.IO.DirectoryInfo subDir2 in subDir1.GetDirectories())
                {
                    System.IO.DirectoryInfo xmlDir = new System.IO.DirectoryInfo(System.IO.Path.Combine(subDir2.FullName, "xml"));
                    if (xmlDir.Exists)
                    {
                        xmlFiles.AddRange(xmlDir.GetFiles("*.xml"));
                    }
                }
            }
