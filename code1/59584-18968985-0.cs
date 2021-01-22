    static void DirSearch(string dir)
    {
        try
        {
            foreach (string f in Directory.GetFiles(dir))
                Console.WriteLine(f);
            foreach (string d in Directory.GetDirectories(dir))
            {
                Console.WriteLine(d);
                DirSearch(d);
            }
    
        }
        catch (System.Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
