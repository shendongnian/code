    using System;
    using System.Windows.Controls;
    
    namespace WpfApp1
    {
        /// <summary>
        /// Interaction logic for MyUserControl.xaml
        /// </summary>
        public partial class MyUserControl : UserControl
        {
            public event MyComboBoxSelectionChangedEventHandler MyComboBoxSelectionChanged;
            public MyUserControl()
            {
                InitializeComponent();
            }
    
            private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
    
                if (e.AddedItems.Count > 0)
                {
                    MyComboBoxSelectionChanged?.Invoke(this,
                        new MyComboBoxSelectionChangedEventArgs() {MyComboBoxItem = e.AddedItems[0]});
                }
            }
        }
    
        public class MyComboBoxSelectionChangedEventArgs : EventArgs
        {
            public object MyComboBoxItem { get; set; }
        }
    
        public delegate void MyComboBoxSelectionChangedEventHandler(object sender, MyComboBoxSelectionChangedEventArgs e);
    
    }
