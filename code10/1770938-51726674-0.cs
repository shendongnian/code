    public static string GetGroupIdentifier(string path)
    {
       var file = System.IO.Path.GetFileNameWithoutExtension(path);
    
       // take only the first two parts
       var id = string.Join("-", file.Split('-').Take(2));
       
       return id;
    }
    
    public static void GroupFilesInFolder(string path)
    {
        foreach(var fileGroup in Directory.GetFiles(path, "*.xml").GroupBy(GetGroupIdentifier))
        {
            Console.WriteLine("For identifier " + fileGroup.Key);
            foreach(var file in fileGroup)
            {
                Console.WriteLine(" - " + file);
            }
            // insert logic to merge the files for this key and do something with the result
        }
    }
