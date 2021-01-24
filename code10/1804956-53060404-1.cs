    var result = System.IO.DirectoryInfo dir = new DirectoryInfo(dirPath);
                 dir.GetFiles().Select((x,i) => new FileElements {
                    filename = x.GetFilenameWithoutExtension,
                    extension = x.Extension,
                    id = i.ToString(),
                    modifiedDate = x.LastWriteTime.ToString()
                });
