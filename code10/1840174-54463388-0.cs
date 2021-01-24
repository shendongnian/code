    public static bool init_access(string file_path)
    {
        try 
        {
            foreach (string item in File
                  .ReadLines(file_path)
                  .Select((line, index) => $"{index + 1} {line}"))
                Console.WriteLine(item);
    
            return true;
        }
        catch (FileNotFoundException) 
        {
            return false;
        }
    }
 
