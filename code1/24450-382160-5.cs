    public bool IsSubSetOf(string InputString, string MatchString) 
    {
      var InputChars = InputString.ToList(); 
      MatchString.ToList().ForEach(Item => InputChars.Remove(Item)); 
      return InputChars.Count == 0;
    }
