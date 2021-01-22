    string path = "C:\\a";
    string[] dirs = Directory.GetDirectories(path, "*.*", SearchOption.AllDirectories);
    string newpath = "C:\\x";
    try
    {
        Directory.CreateDirectory(newpath);
    }
    catch (IOException ex)
    {
        Console.WriteLine(ex.Message);
    }
    for (int j = 0; j < dirs.Length; j++)
    {
        try
        {
            Directory.CreateDirectory(dirs[j].Replace(path, newpath));
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
    string[] files = Directory.GetFiles(path, "*.*", SearchOption.AllDirectories);
    for (int j = 0; j < files.Length; j++)            
    {
        try
        {
            File.Copy(files[j], files[j].Replace(path, newpath));
        }
        catch (IOException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
