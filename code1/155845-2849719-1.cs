    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace MenuTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                Groups = new List<Group>();
                Groups.Add(new Group() { Name = "Group1", Id = 1 });
                Groups.Add(new Group() { Name = "Group2", Id = 2 });
                Groups.Add(new Group() { Name = "Group3", Id = 3 });
    
                DataContext = this;
            }
    
            public List<Group> Groups { get; set; }
    
            private void OnGroupMenuItemClick(object sender, RoutedEventArgs e)
            {
                MenuItem menuItem = e.OriginalSource as MenuItem;
                Group group = menuItem.DataContext as Group;
            }
        }
    
        public class Group
        {
            public string Name { get; set;}
            public int Id { get; set;}
        }
    }
