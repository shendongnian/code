    var mg = Regex.Match( "[(34) Some Text - Some Other Text]", @"\((\d+)\)");
    
    if (mg.Success)
    {
      var num = mg.Groups[1].Value; // num == 34
    }
      else
    {
      // No match
    }
