    var text = "PRODUCT MANAGER OFFICE";
    string Shortform = "";
    var punctuation = text.Where(Char.IsPunctuation).Distinct().ToArray();
    var words = text.Split().Select(x => x.Trim(punctuation));
    foreach (string word in words)
    {
      ///Now in the loop, we will get the first character of each word and pass it to the ShortForm variable 
      Shortform = Shortform + text.Substring(0, 1);
    }
