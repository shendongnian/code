    var result = System.IO.DirectoryInfo dir = new DirectoryInfo(dirPath);
                 dir.GetFiles().Select((x,i) => new FileElements {
                    filename = Path.GetFileNameWithoutExtension(x.FullName),
                    extension = x.Extension,
                    id = i.ToString(),
                    modifiedDate = x.LastWriteTime.ToString()
                });
