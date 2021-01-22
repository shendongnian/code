    public CustomClass TranslateME(XElement source)
    {
      CustomClass result = new CustomClass();
      result.Words = (int) source.Attribute("Words");
      result.Score = (int) source.Attribute("Score");
    
      XAttribute highScore = source.Attribute("HighScore");
      result.HighScore = (highScore == null) ? 0 : (int) highScore;
    
      result.NMs = source
        .Elements("NM")
        .Select(x => x.Value)
        .ToList();
    
      result.IE = source
        .Element("IE").Value;
    
      result.SubEntries = source
        .Elements("M1")
        .Select(x => TranslateM1(x))
        .ToList();
    
      return result;
    }
