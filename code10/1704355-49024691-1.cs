    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            rowPlaces(5, 0.2, 0.2);
        }
        public BoxView[,] rowPlaces(int count, double x, double y)
        {
            BoxView[,] digitBoxViews = new BoxView[count, 2];
            double sourcey = y;
            // Create and assemble the BoxViews.
            double xIncrement = 0.25 / count;
            double yIncrement = 0.5 / count;
            for (int index = 0; index < count; index++)
            {
                for (int col = 0; col < 2; col++)
                {
                    for (int row = 0; row < count; row++)
                    {
                        // Create the index BoxView and add to layout.
                        BoxView boxView = new BoxView();
                        digitBoxViews[row, col] = boxView;
                        absoluteLayout.Children.Add(boxView,
                            new Rectangle(x, y, 10, 10),
                                                    AbsoluteLayoutFlags.PositionProportional);
                        digitBoxViews[row, col].Color = Color.Blue;
                        y += yIncrement;
                    }
                    x += xIncrement;
                    y = sourcey;
                }
                x += xIncrement;
            }
            return digitBoxViews;
        }
    }
    
