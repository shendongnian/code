     // Determine whether the directory exists.
            if (Directory.Exists(path)) 
            {
                Console.WriteLine("That path exists already.");
                return;
            }
    
            // Try to create the directory.
            DirectoryInfo di = Directory.CreateDirectory(path);
            Console.WriteLine("The directory was created successfully at {0}.", Directory.GetCreationTime(path));
