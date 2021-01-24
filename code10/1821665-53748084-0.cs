    using (var writer = File.AppendText(folder + ".tfcs"))
    {
        foreach (var file in fileArray)
        {
            writer.WriteLine(file.Substring(49, file.Length - 49));
            indexFiles++;
        }
    }
    Console.Clear();
    Console.WriteLine("Scanning Folder:");
    Console.WriteLine(folder);
    Console.WriteLine("Files found:" + fileArray.Length);
    Console.WriteLine("Files written to Database:" + indexFiles);
