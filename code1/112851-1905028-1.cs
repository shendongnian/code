    public ImageSource GetGlowingImage(string name)
    {
      switch (name)
      {
        case "Andromeda":
          return (ImageSource)FindResource("andromeda64");
        default:
          return null;
      }
    }
