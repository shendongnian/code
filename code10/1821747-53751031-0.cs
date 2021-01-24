        //if your list is constructed elsewhere 
         List<string> listNumbers = new List<string>(); 
        //addrange can still be used to populate it 
        string[] lines = System.IO.File.ReadAllLines("Numbers.txt");
        listNumbers.AddRange(lines);
