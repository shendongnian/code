    // This will require a reference to System.Text
    StringBuilder input =new StringBuilder(Input);
      foreach (Block block in Blocks)
      {
        input = input.Replace("[" + block.OrginalText + "]", block.Process);
      }
      return input.ToString();
