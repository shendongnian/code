    words = new List<Word>(); 
    Console.WriteLine("Please wait, compiling words list..."); 
    TextReader tr = new StreamReader(DICT); 
    string line;
    while((line = tr.ReadLine()) != null)
    if(!string.IsNullOrEmpty(line.Trim()))
    { 
     words.Add(new Word(line)); 
    } 
    Console.WriteLine("List compiled with " + words.Count + " words.");
