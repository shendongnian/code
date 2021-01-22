    static bool FileInUse(string path)
        {
            try
            {
                using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
                {
                    fs.CanWrite
                }
                return false;
            }
            catch (IOException ex)
            {
                return true;
            }
        }
    string filePath = "C:\\Documents And Settings\\yourfilename";
    bool isFileInUse;
    isFileInUse = FileInUse(filePath);
    // Then you can do some checking
    if (isFileInUse)
       Console.WriteLine("File is in use");
    else
       Console.WriteLine("File is not in use");
