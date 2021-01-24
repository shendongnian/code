    private void DoStuff ()
    {
        if (emaillower != 0)  // emaillower = the length
        {            
            OldoCombo.RemoveAll (x => Match(x, emaillower )); 
        }
        foreach(string s in OldCombo)
            Console.WriteLine(s);
    }
    private bool Match (string value, int maxLength)
    {
        string pattern = "[a-zA-Z0-9@.]+[:]";;
        Match match = Regex.Match(value, pattern);
        return match.Success && match.Length < maxLength;
    }
