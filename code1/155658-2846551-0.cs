    private string WrapText(string text)
    {
      string[] words = text.Split(' ');
      StringBuilder sb = new StringBuilder();
      float linewidth = 0f;
      float maxLine = 250f; //a bit smaller than the box so you can have some padding...etc
      float spaceWidth = spriteFont.MeasureString(" ").X;
      
      foreach (string word in words)
      {
        Vector2 size = spriteFont.MeasureString(word);
        if (linewidth + size.X < 250)
        {
          sb.Append(word + " ");
          linewidth += size.X + spaceWidth;
        } 
        else
        {
          sb.Append("\n" + word + " ");
          linewidth = size.X + spaceWidth;
        }
      }
      return sb.ToString();
    }
