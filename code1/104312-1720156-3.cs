    public static class Grid_Named
    {
      // Define Grid_Name.Column property
      public static string GetColumn(DependencyObject obj) { return (string)obj.GetValue(ColumnProperty); }
      public static void SetColumn(DependencyObject obj, string value) { obj.SetValue(ColumnProperty, value); }
      public static readonly DependencyProperty ColumnProperty = DependencyProperty.RegisterAttached("Column", typeof(string), typeof(Grid_Named), new UIPropertyMetadata
      {
        PropertyChangedCallback = (obj, e) =>
          {
            if(e.OldValue!=null) BindingOperations.ClearBinding(obj, Grid.ColumnProperty);
            if(e.NewValue!=null) BindingOperations.SetBinding(obj, Grid.ColumnProperty, _columnBinding);
          },
      });
      // Define Grid_Named.Row property
      public static string GetRow(DependencyObject obj) { return (string)obj.GetValue(RowProperty); }
      public static void SetRow(DependencyObject obj, string value) { obj.SetValue(RowProperty, value); }
      public static readonly DependencyProperty RowProperty = DependencyProperty.RegisterAttached("Row", typeof(string), typeof(Grid_Named), new UIPropertyMetadata
      {
        PropertyChangedCallback = (obj, e) =>
        {
          if(e.OldValue!=null) BindingOperations.ClearBinding(obj, Grid.RowProperty);
          if(e.NewValue!=null) BindingOperations.SetBinding(obj, Grid.RowProperty, _rowBinding);
        },
      });
      // Construct bindings for Grid.Column and Grid.Row
      private static BindingBase _columnBinding = BuildBinding(grid => grid.ColumnDefinitions, ColumnProperty);
      private static BindingBase _rowBinding = BuildBinding(grid => grid.RowDefinitions, RowProperty);
      private static BindingBase BuildBinding(Func<Grid, IList> getDefinitions, DependencyProperty nameProperty)
      {
        var binding = new MultiBinding
        {
          Converter = new NameLookupConverter { GetDefinitions = getDefinitions }
        };
        binding.Bindings.Add(new Binding { Path = new PropertyPath(nameProperty), RelativeSource = RelativeSource.Self });
        binding.Bindings.Add(new Binding { RelativeSource = new RelativeSource(RelativeSourceMode.FindAncestor, typeof(Grid), 1) });
        return binding;
      }
      // Converter to take a row/column name and a Grid, and find the index of that row/column in the grid
      private class NameLookupConverter : IMultiValueConverter
      {
        public Func<Grid, IList> GetDefinitions;
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
          var name = values[0] as string;
          var grid = values[1] as Grid;
          if(grid==null || name==null) return 0;
          
          object namedObject = grid.FindName(name);
          if(namedObject==null) return 0;
          int index = GetDefinitions(grid).IndexOf(namedObject);
          return index<0 ? 0 : index;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
          throw new NotImplementedException();
        }
      }
    }
