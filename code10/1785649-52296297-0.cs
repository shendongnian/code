    string Data = "";
    using(StreamReader Sr = new StreamReader(Path))
    {
        while(!Sr.EndOfStream())
        {
            string UseMe = Sr.ReadLine();
            Data += UseMe;        
        }
    }
