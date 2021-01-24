    public partial class SilverlightControl3 : UserControl
    {
        public SilverlightControl3()
        {
            InitializeComponent();
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            objectVisual.Children.Add(ChangeContentObject());
        }
        private Grid ChangeContentObject()
        {
            Grid g = new Grid();
            g.Background = new SolidColorBrush(Colors.Red);
            g.HorizontalAlignment = HorizontalAlignment.Stretch;
            g.VerticalAlignment = VerticalAlignment.Stretch;
            // add grid line to show columns border
            g.ShowGridLines = true;
            ColumnDefinition columnDefinitionForPath = new ColumnDefinition();
            columnDefinitionForPath.Width = new GridLength(4, GridUnitType.Star);
            ColumnDefinition columnDefinitionForEmpty = new ColumnDefinition();
            columnDefinitionForEmpty.Width = new GridLength(6, GridUnitType.Star);
            g.ColumnDefinitions.Add(columnDefinitionForPath);
            g.ColumnDefinitions.Add(columnDefinitionForEmpty);
            var p1 = new Path();
            p1.Stroke = new SolidColorBrush(Colors.Blue);
            p1.StrokeThickness = 2;
            p1.Stretch = Stretch.Fill;
            p1.HorizontalAlignment = HorizontalAlignment.Stretch;
            g.Children.Add(p1);
            Grid.SetColumn(p1, 0);
            var b1 = new Binding
            {
                Source = "M 10,100 C 10,300 300,-200 300,100"
            };
            BindingOperations.SetBinding(p1, Path.DataProperty, b1);
            // you dont necessarily need this here, you can keep it empty like before
            /*
            var gridChild = new Grid();
            g.Children.Add(gridChild);
            Grid.SetColumn(gridChild, 1);
            */
            return g;
        }
    }
