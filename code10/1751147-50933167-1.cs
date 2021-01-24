    if (inputDrive == "search.system")
    {
        try
        {
            string Desktop = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string DeleteFile = @"delete.txt";
            string filePath = System.IO.Path.Combine(Desktop, DeleteFile);
    
            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
                Console.WriteLine("File has been deleted");
                Console.ReadLine();
            }
            else
            {
                Console.Write("File could not be found");
                Console.ReadLine();
            }
        }
        catch (System.Exception ex)
        {
            Console.WriteLine($"search has encountered an error: {ex}");
            Console.ReadLine();
        }
    }
