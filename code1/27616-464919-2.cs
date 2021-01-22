      public class TreeLevelConverter : IValueConverter
      {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
          var level = -1;
          if (value is DependencyObject )
          {
            var parent = VisualTreeHelper.GetParent(value as DependencyObject );
            while (!(parent is TreeView) && (parent != null))
            {
              if (parent is TreeViewItem) 
                level++;
              parent = VisualTreeHelper.GetParent(parent);
            }
          }
          return level;
        }
    
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
          throw new System.NotImplementedException();
        }
      }
