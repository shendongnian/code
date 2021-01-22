    Queue<string> stringQueue = new Queue<string();
    string tempLine = "";
    StreamReader reader = new StreamReader(inputFileName);
    do
    {
         tempLine = reader.ReadLine();
         if (lineIsGood(tempLine))
         {
              stringQueue.Enqueue(tempLine);
         }
    }   
    while(reader.Peek() != -1);
    reader.Close();
    StreamWriter writer = new StreamWriter(inputFileName);     
    do
    {
        tempLine = (string) stringQueue.Dequeue();
        writer.WriteLine(tempLine);        
    }
    while (stringQueue.Count != 0);
    writer.Close();
