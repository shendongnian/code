    string startingdir = @"K:\qload";
    string dest = @"K:\D\ho\jlg\load\dest";
    string[] files = Directory.GetFiles(startingdir, "*.txt");
    foreach (string file in files)
    {
        var outfile = Path.Combine(dest, Path.GetFileName(file));
        using (StreamReader reader = new StreamReader(file))
        using (StreamWriter writer = new StreamWriter(outfile))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                writer.WriteLine(line.Replace("|", "\\"));
                line = reader.ReadLine();
            }
        }
    }
