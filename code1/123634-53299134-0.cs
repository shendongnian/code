    private String EvaluatePath(String path){
       
        try
        {
            String folder = Path.GetDirectoryName(path);
            if (!Directory.Exists(folder))
            {
                // Try to create the directory.
                DirectoryInfo di = Directory.CreateDirectory(folder);
            }
        }
        catch (IOException ioex)
        {
            Console.WriteLine(ioex.Message);
            return "";
        }
        return path;
    }
