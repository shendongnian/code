    if (!this.IsPostBack)
    {
      //with LINQ
      System.Collections.Generic.List<System.Drawing.KnownColor> ColorList = new List<System.Drawing.KnownColor>();
      ColorList.AddRange(((System.Drawing.KnownColor[])System.Enum.GetValues(typeof(System.Drawing.KnownColor))).ToList());
      //with LINQ (more explicit)
      ColorList = new List<System.Drawing.KnownColor>();
      System.Drawing.KnownColor[] colors = (System.Drawing.KnownColor[])System.Enum.GetValues(typeof(System.Drawing.KnownColor));
      ColorList.AddRange(colors.ToList());
      //without
      ColorList = new List<System.Drawing.KnownColor>();
      colors = (System.Drawing.KnownColor[])System.Enum.GetValues(typeof(System.Drawing.KnownColor));
      foreach (System.Drawing.KnownColor color in colors)
      {
        ColorList.Add(color);
      }
    }
