    public class MovieControl : Control
    {
        public Movies Movie { get; protected set; }
        // Changed the constructor to now take an image as well, so you can
        // pass in the already resized image
        public MovieControl(Movies M1, Bitmap image, bool show, MainForm current)
        {
            InitializeComponent();
            Current = current;
            bunifuImageButton1.Image = image ?? Properties.Resources.no_image_available; // Sanity check
            Movie = M1;
        }
        public void UpdateMovieAndImage(Movies movie, Image image)
        {
            if (bunifuImageButton1.Image != null
                && bunifuImageButton1.Image != Properties.Resources.no_image_available)
            {
                // Only dispose if it isn't null and isn't the "No Image" image
                binifuImageButton1.Image.Dispose();
            }
            bunifuImageButton1.Image = image;
            Movie = movie;
        }
    }
