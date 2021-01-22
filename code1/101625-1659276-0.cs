    StreamReader reader = new StreamReader(inputFileName);
    StreamWriter writer = new StreamWriter(inputFileName);     
    do
    {
         String tempLine = reader.ReadLine();
         if (lineIsGood(tempLine))
         {
              writer.WriteLine(tempLine); 
         }
    }   
    while(reader.Peek() != -1);
        
