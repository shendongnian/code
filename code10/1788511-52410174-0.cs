    public partial class Form1 : Form
    {
      public Form1()
      {
        InitializeComponent();
        pictureBox1.Region = CreateRegion(Properties.Resources.LU);
      }
    
      private static Region CreateRegion(Bitmap maskImage)
      {
        // We're using pixel 0,0 as the "transparent" color.
        Color mask = maskImage.GetPixel(0, 0);
        GraphicsPath graphicsPath = new GraphicsPath();
        for (int x = 0; x < maskImage.Width; x++)
        {
          for (int y = 0; y < maskImage.Height; y++)
          {
            if (!maskImage.GetPixel(x, y).Equals(mask))
            {
              graphicsPath.AddRectangle(new Rectangle(x, y, 1, 1));
            }
          }
        }
    
        return new Region(graphicsPath);
      }
    }
