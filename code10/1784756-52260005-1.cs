    var userString = ReadUserString();
    string[] grammarFile = File.ReadAllLines(@"C:\Users\user_name\Desktop\Text.txt");
    var resp = -1;
   
    for(int i = 0; i < grammarFile.Length; ++i)
    {
        var grammarEntry = grammarFile[i];
    
        if(grammarEntry.ToRegex().IsMatch(userString))
        {
            resp = i;
            break;
        }
    }
    
    Console.WriteLine(resp);
