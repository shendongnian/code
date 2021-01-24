    public static bool init_access(string file_path)
    {
        if (File.Exists(file_path))
        {
            var counter = 0;
            File.ReadAllLines(file_path).ToList().ForEach(x => Console.WriteLine(counter++ + " " + x));
            return true;
        }
        return false;
    }
