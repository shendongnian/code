    int count = 0;
    Queue<string> dirs = new Queue<string>();
    dirs.Enqueue(@"d:\Test");
    while(dirs.Count > 0) {
        string dir = dirs.Dequeue();
        try
        {
            foreach (string subdir in Directory.GetDirectories(dir))
            {
                dirs.Enqueue(subdir);
            }
        }
        catch (Exception ex) { Console.Error.WriteLine(ex); }// access denied etc
        foreach (string file in Directory.GetFiles(dir, "*.rar"))
        {
            try
            {
                File.Delete(file);
                count++;
            }
            catch (Exception ex) { Console.Error.WriteLine(ex); }// access denied etc
        }
    }
    Console.WriteLine("Deleted: " + count);
