    private Color RgbExample()
    {
        // Create a green color using the FromRgb static method.
        Color myRgbColor = new Color();
        myRgbColor = Color.FromRgb(0, 255, 0);
        return myRgbColor;
    }
    To get all colors 
    List<System.Windows.Media.Color> listOfMediaColours = new List<System.Windows.Media.Color>();
    foreach(KnownColor color in Enum.GetValues(typeof(KnownColor)))
    {
        System.Drawing.Color col = System.Drawing.Color.FromKnownColor(color);
        listOfMediaColours.Add(System.Windows.Media.Color.FromArgb(col.A, col.R, col.G, col.B));
    }
