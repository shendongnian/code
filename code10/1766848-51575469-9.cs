    var regstr = "^ERISRequest_.*?";
    
    DirectoryInfo di = new DirectoryInfo(@"C:\");
    foreach (FileInfo fi in di.GetFiles())
    {
        string name = Path.GetFileNameWithoutExtension(fi.Name);
        if (Regex.IsMatch(name, regstr))
        {
            Console.WriteLine(name.Replace("ERISRequest_", ""));
        }
    }
