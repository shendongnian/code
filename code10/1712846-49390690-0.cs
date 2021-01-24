    do
    {
        //string test = questions[qCounter] = objReader.ReadLine();
    
    
        string test = question.Split('?')[qCounter];
        qCounter++;
    
        foreach (char part in test)
        {
    
            Console.WriteLine(part);
            Console.ReadLine();
        }
    } while (objReader.Peek() != -1 && qCounter < quest);
