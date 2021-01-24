    // somewhere in after selecting all files
    File.WriteAllLines(@"c:\temporario\order.txt", listimga.Items.Select(t=>t.ToString()));
    public string[] GetFilesImg4() //jpg files
    {
        string tempPath = @"C:\temporario";
        if (!Directory.Exists(tempPath))
        {
            var orderedFilenames = File.ReadAllLines(Path.Combine(tempPath, "order.txt")); // list of files loaded in order
            foreach (string filename in orderedFilenames)
            {
                if (!filename.Contains("protected"))
                    list4.Add(Path.Combine(tempPath, filename);
            }
        }
        return (string[])list4.ToArray(typeof(string));
    }
