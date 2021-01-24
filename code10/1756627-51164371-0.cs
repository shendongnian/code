    var destinations = new List<string>() {dest1,dest2,dest3, ...};
    
    SPFile destFile = null;
    
    foreach(var destination in destinations)
    {
        try
        {
            destFile = projectid.RootFolder.Files.Add(destination, fileBytes, false);
            // we are working
            Console.WriteLine($"Destination Success!!: {destination}");
            break;
        }
        catch(exception ex)
        {
             Console.WriteLine($"Destination failed : {destination} - {ex.Message}");
        }
    } 
    
    if(destFile != null)
       // do something with your destFile 
    else
       // oh noez!!!
