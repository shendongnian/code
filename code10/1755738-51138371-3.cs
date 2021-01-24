    public class Window14ViewModel
    {
        public Window14ViewModel()
        {
            DrawCommand = new RelayCommand(Draw);
            ResetCommand = new RelayCommand(Clear);
        }
        public ObservableCollection<Rectangle> Items { get; } = new ObservableCollection<Rectangle>();
        public RelayCommand DrawCommand { get; }
        public RelayCommand ResetCommand { get; }
        public int Width { get; set; }
        public int Height { get; set; }
        private void Draw()
        {
            Clear();
            int xParts = 10;
            int yParts = 10;
            for (int i = 0; i < xParts; i++)
            {
                for (int j = 0; j < yParts; j++)
                {
                    // Create a rectangle.
                    Rectangle myRectangle = new Rectangle();
                    myRectangle.Width = Width;
                    myRectangle.Height = Height;
                    myRectangle.Margin = new Thickness((Convert.ToInt32(myRectangle.Width) + 1) * i, (Convert.ToInt32(myRectangle.Height) + 1) * j, 0, 0);
                    myRectangle.Fill = new SolidColorBrush(Color.FromArgb(170, 51, 51, 255));
                    Items.Add(myRectangle);
                }
            }
        }
        private void Clear()
        {
            Items.Clear();
        }
    }
