    List<MemoryStream> list = new List<MemoryStream>();
    string[] fileNames = Directory.GetFiles("Path");
    for (int iFile = 0; iFile < fileNames.Length; iFile++)
    {
        using (FileStream fs = new FileStream(fileNames[iFile], FileMode.Open))
        {
            byte[] b = new byte[fs.Length];
            fs.Read(b, 0, (int)fs.Length);
            list.Add(new MemoryStream(b));
        }
    }
