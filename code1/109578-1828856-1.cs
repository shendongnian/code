    namespace TemplatedListBoxItemWithButton
    {
        using System.Collections.Generic;
        using System.Windows;
        using System.Windows.Controls;
    
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                list.ItemsSource = new List<DataItem>
                    {
                        new DataItem(1),
                        new DataItem(2),
                        new DataItem(3),
                        new DataItem(4),
                        new DataItem(5),
                    };
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                var id = ((DataItem) ((Button) sender).DataContext).Id; // breakpoint
            }
        }
    
        public class DataItem
        {
            public DataItem(int id)
            {
                Id = id.ToString();
                Title = "this is item " + Id;
                IsSelected = id % 2 == 0;
            }
    
            public bool IsSelected { get; set; }
            public string Id { get; set; }
            public string Title { get; set; }
    
            public override string ToString()
            {
                return string.Format("IsSelected: {0}, Id: {1}, Title: {2}", IsSelected, Id, Title);
            }
        }
    }
