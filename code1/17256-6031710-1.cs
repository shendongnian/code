    public static class ColorExtensions
    {
      // Gets a color that will be readable on top of a given background color
      public static Color GetForegroundColor(this Color input)
      {
        // Math taken from one of the replies to
        // http://stackoverflow.com/questions/2241447/make-foregroundcolor-black-or-white-depending-on-background
        if (Math.Sqrt(input.R * input.R * .241 + input.G * input.G * .691 + input.B * input.B * .068) > 128)
          return Color.Black;
        else
          return Color.White;
      }
      
      // Converts a given Color to gray
      public static Color ToGray(this Color input)
      {
        int g = (int)(input.R * .299) + (int)(input.G * .587) + (int)(input.B * .114);
        return Color.FromArgb(input.A, g, g, g);
      }
    }
