    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
        public partial class MainWindow
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var button = (Button) sender;
    
                // where is the element you want, relative row/column to this one
                var relativeX = 1;
                var relativeY = 1;
    
                UIElement result;
    
                if (TryGetAdjacent(button, relativeX, relativeY, out result))
                {
                    MessageBox.Show("Yes !");
    
                    // TODO further check whether element satisfies some condition
                }
            }
    
            private bool TryGetAdjacent(Button button, int relativeX, int relativeY, out UIElement result)
            {
                result = null;
    
                var row = Grid.GetRow(button);
                var col = Grid.GetColumn(button);
    
                var parent = (Grid) button.Parent;
                var rows = parent.RowDefinitions.Count;
                var cols = parent.ColumnDefinitions.Count;
    
    
                var x = row + relativeX;
                var y = col + relativeY;
                if (x < 0 || x >= cols || y < 0 || y >= rows)
                    return false;
    
                foreach (var child in parent.Children.Cast<UIElement>())
                {
                    var col1 = Grid.GetColumn(child);
                    var row1 = Grid.GetRow(child);
    
                    if (row1 != x || col1 != y)
                        continue;
    
                    result = child;
                    return true;
                }
    
                return false;
            }
        }
    }
