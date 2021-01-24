    public String DoTest()
            {
                var fileContent = new StringBuilder();
                String fileName = "";
                String[] filesNames = System.IO.Directory.GetFiles(logDir);
                for (int i = 0; i < filesNames.Length; i++)
                {
                    fileName = filesNames[i];
                    if (fileName.ToLower().Contains("aud"))
                    {
                        fileContent.Append(System.IO.File.ReadAllText(fileName));
                    }
                }
                
                return fileContent;
            }
