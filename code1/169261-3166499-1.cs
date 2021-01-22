    using System.Collections.Generic;
    using System.Windows;
    using System.Windows.Controls;
    
    namespace ListBoxTest
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
    
                DataContext = new VM();
            }
    
            private void OnCheckBoxClick(object sender, RoutedEventArgs e)
            {
                VM vm = DataContext as VM;
                CheckBox checkBox = sender as CheckBox;
                Extra extra = checkBox.DataContext as Extra;
                if (checkBox.IsChecked.GetValueOrDefault())
                {
                    vm.CheckedExtras.Add(extra);
                }
                else
                {
                    vm.CheckedExtras.Remove(extra);
                }
            }
        }
    
        public class VM
        {
            public VM()
            {
                CheckedExtras = new List<Extra>();
                AllExtras = new List<Extra>() { new Extra() { Name = "A" }, new Extra() { Name = "B" }, new Extra() { Name = "C" }, };
            }
    
            public List<Extra> CheckedExtras { get; private set; }
            public List<Extra> AllExtras { get; private set; }
        }
    
        public class Extra
        {
            public string Name { get; set; }
        } 
    }
