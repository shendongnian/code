    public class ViewModel
    {
        public ViewModel()
        {
            DrawCommand = new RelayCommand(Draw);
            ResetCommand = new RelayCommand(Clear);
        }
        public ObservableCollection<Model> Items { get; } = new ObservableCollection<Model>();
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
                    Model model = new Model();
                    model.Width = Width;
                    model.Height = Height;
                    model.Margin = new Thickness((model.Width + 1) * i, (model.Height + 1) * j, 0, 0);
                    model.Fill = new SolidColorBrush(Color.FromArgb(170, 51, 51, 255));
                    Items.Add(myRectangle);
                }
            }
        }
        private void Clear()
        {
            Items.Clear();
        }
    }
