    // Call the WalkDirectoryTree with the parameters below
    // Notice that I have removed the * in the search pattern    
    var dirs = WalkDirectoryTree(@"E:\", @"something-");
    List<string> WalkDirectoryTree(string root, string search)
    {
        try
    	{
            var  files = Directory.GetFiles(root, "*.*");
        }
        // This is thrown if even one of the files requires permissions greater
        // than the application provides.
        catch (UnauthorizedAccessException e)
        {
            // This code just writes out the message and continues to recurse.
            // You may decide to do something different here. For example, you
            // can try to elevate your privileges and access the file again.
            Console.WriteLine(e.Message);
            return new List<string>();
        }
    
        catch (System.IO.DirectoryNotFoundException e)
        {
            Console.WriteLine(e.Message);
            return new List<string>();
        }
    
        // Now find all the subdirectories under this directory.
        List<string> subDirs = new List<string>();
    	List<string> curDirs = Directory.GetDirectories(root).ToList();
        foreach (string s in curDirs)
        {
            if(s.StartsWith(search))
                subDirs.Add(s);
            var result = WalkDirectoryTree(s, search);
            subDirs.AddRange(result);
        }
    	return subDirs;
    }
