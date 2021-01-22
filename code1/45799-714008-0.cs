    int counter = 0;
    string line;
    
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\t1.txt");
    while((line = file.ReadLine()) != null)
    {
        counter++;
    }
    file.Close();
