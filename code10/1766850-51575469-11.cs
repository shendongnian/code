        Regex regex = new Regex(@"ERISRequest_(?<val>[a-zA-Z0-9]{1,})");
        DirectoryInfo di = new DirectoryInfo(@"C:\");
        foreach (FileInfo fi in di.GetFiles())
        {
            var match = regex.Match(Path.GetFileNameWithoutExtension(fi.Name));
            if (match.Success)
            {
                Console.WriteLine(match.Groups["val"].Value);
            }
        }
        Console.ReadLine();
