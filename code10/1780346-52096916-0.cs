    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext= new MyVm();
        }
        private void BtnWin1_OnClick(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as MyVm;
            var relativePoint = ((Button)sender).TransformToAncestor(this).Transform(new Point(0, 0));
            relativePoint.X += this.Left;
            relativePoint.Y += this.Top;
            dataContext?.OpenWindow1Command.Execute(relativePoint);
        }
        private void BtnWin2_OnClick(object sender, RoutedEventArgs e)
        {
            var dataContext = DataContext as MyVm;
            var relativePoint = ((Button)sender).TransformToAncestor(this).Transform(new Point(0, 0));
            relativePoint.X += this.Left;
            relativePoint.Y += this.Top;
            dataContext?.OpenWindow2Command.Execute(relativePoint);
        }
    }
