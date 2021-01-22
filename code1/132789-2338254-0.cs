    private void PrintLoop()
    {
        while (true)
        {
            if (documents.Count > 0)
            {
                PrintDocument document = documents.Dequeue();
                document.Print();
    
            }
            else
            {
                Thread.Sleep(1000);
            }
        }
    }
