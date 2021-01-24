    int counter = 0;  
    string line;  
    
    // Read the file and display it line by line.  
    System.IO.StreamReader file =   
        new System.IO.StreamReader(@"c:\test.txt");  
    while((line = file.ReadLine()) != null)  
    {  
        System.Console.WriteLine (line);  
        counter++;  
    }  
    
    file.Close();  
    System.Console.WriteLine("There were {0} lines.", counter);  
    // Suspend the screen.  
    System.Console.ReadLine();  
