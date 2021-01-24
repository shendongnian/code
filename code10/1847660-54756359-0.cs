    var children = new List<ChildDetails>();
    string line;   
    
    try {  
        using (StreamReader file = new StreamReader(@"C:\Users\tomik\Desktop\School Y2 T2\Application Development\LAB3\\WindowsFormsApplication1\BodkinVanHorn.docx");   
        {
            while ((line = file.ReadLine()) != null)
            {
                string[] words = line.Split('-');
                children.Add(newChildDetails(words[0], DateTime.ParseExact(words[1],"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None), words[2]));
            }
        }
    } 
    catch (Exception ex) 
    {
        // Catch some issue
        Console.WriteLine("The file could not be read: maybe doesnt exists");
    }
