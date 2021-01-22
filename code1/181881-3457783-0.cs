    lock(someSharedObject)
    {
        using (var fs = File.Open(filePath, FileMode.Append)) //Exception here
        {
            using (var sw = new StreamWriter(fs))
            {
                sw.WriteLine(text);
            }
        }
    }
