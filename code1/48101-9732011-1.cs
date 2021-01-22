      using System;
      using System.Collections.Generic;
      using System.Globalization;
      using System.Linq;
      using System.Windows.Controls;
      using System.Windows.Controls.Primitives;
      using System.Windows.Data;
      namespace RowNumber
      {
         public class ListItemIndexConverter : IValueConverter
         {
            // Value should be ListBoxItem that contains the current record. RelativeSource={RelativeSource AncestorType=ListBoxItem}
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {
               var lbi = (ListBoxItem)value;
               var listBox = lbi.GetVisualAncestors().OfType<ListBox>().First();
               var index = listBox.ItemContainerGenerator.IndexFromContainer(lbi);
               // One based. Remove +1 for Zero based array.
               return index + 1;
            }
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) { throw new NotImplementedException(); }
         }
         public partial class MainPage : UserControl
         {
            public MainPage()
            {
               // Required to initialize variables
               InitializeComponent();
            }
            public List<string> Test { get { return new[] { "Foo", "Bar", "Baz" }.ToList(); } }
         }
      }
