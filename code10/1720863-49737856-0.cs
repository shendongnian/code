    if (Directory.Exists(myfilePath))
    {
    File.AppendAllText(myfilePath + "\\" + MyFileName + ".txt", "Testing ......");
                }
                else
                {
                    
                    Directory.CreateDirectory(myfilePath);
                    File.AppendAllText(myfilePath + "\\" + MyFileName + ".txt", "Testing ......");
                }
