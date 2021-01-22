        public class GridExtensions
        {
            public static Int32 GetGridRowCount(DependencyObject obj)
            {
                return (Int32)obj.GetValue(GridRowCountProperty);
            }
    
            public static void SetGridRowCount(DependencyObject obj, UIElementCollection value)
            {
                obj.SetValue(GridRowCountProperty, value);
            }
    
            // Using a DependencyProperty as the backing store for GridRowCount.  This enables animation, styling, binding, etc...
            public static readonly DependencyProperty GridRowCountProperty =
                DependencyProperty.RegisterAttached("GridRowCount", typeof(Int32), typeof(Grid), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnGridRowCountChenged)));
    
            public static void OnGridRowCountChenged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
            {
                if (e.NewValue != null && obj is Grid)
                {
                    Int32 rowCount = (Int32)e.NewValue;
                    Grid grid = (Grid)obj;
    
                    grid.RowDefinitions.Clear();
                    grid.Children.Clear();
    
                    for (int i = 1; i <= rowCount; i++)
                    {
                        grid.RowDefinitions.Add(new RowDefinition());
                        Grid.SetRow(grid.Children[index], i - 1);
                    }
                }
            }
        }
