    List<char> characters = new List<char>();
    
    characters.AddRange("string".ToCharArray());
    
    characters.Reverse();
    
    string reversed = new string(characters.ToArray());
