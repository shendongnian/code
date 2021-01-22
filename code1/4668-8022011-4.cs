    string source_dir = @"E:\";
    string destination_dir = @"C:\";
    
    // substring is to remove destination_dir absolute path (E:\).
    
    // Create subdirectory structure in destination    
        foreach (string dir in System.IO.Directory.GetDirectories(source_dir, "*", System.IO.SearchOption.AllDirectories))
        {
    		System.IO.Directory.CreateDirectory(destination_dir + dir.Substring(source_dir.Length));
			// Example:
			//     > C:\sources (and not C:\E:\sources)
        }
        foreach (string file_name in System.IO.Directory.GetFiles(source_dir, "*.*", System.IO.SearchOption.AllDirectories))
        {
    		System.IO.File.Copy(file_name, destination_dir + file_name.Substring(source_dir.Length));
        }
