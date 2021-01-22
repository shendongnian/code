    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }
        private void Content_TextChanged(object sender, TextChangedEventArgs e)
        {
            int x1;
            int x2;
            int y1;
            int y2;
            if (int.TryParse(tbX1.Text, out x1) && int.TryParse(tbX2.Text, out x2) && int.TryParse(tbY1.Text, out y1) && int.TryParse(tbY2.Text, out y2))
            {
                lnDraw.X1 = x1;
                lnDraw.X2 = x2;
                lnDraw.Y1 = y1;
                lnDraw.Y2 = y2;
            }
        }
    }
