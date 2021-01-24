    StringBuilder finalString = new StringBuilder();
    
    foreach(var item in myInts)
    {
       int unicode = item;
       char character = (char) unicode;
       string text = character.ToString();
       builder.Append(text)
    }
