    public Dictionary<string, string> ToPropertyDictionary(User theUser)
    {
      Dictionary<string, string> result = new Dictionary<string, string>();
      result.Add("Name", theUser.Name);
      result.Add("LastName", theUser.Name);
      return result;
    }
