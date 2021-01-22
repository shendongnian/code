    using (StreamReader reader = new StreamReader(stream))
    {
      string contents = reader.ReadToEnd();
      Regex r = new Regex("[0-9]");
      Match m = r.Match(contents );
      while (m.Success) 
      {
         int number = Convert.ToInt32(match.Value);
         // do something with the number
         m = m.NextMatch();
      }
    }
