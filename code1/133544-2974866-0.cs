    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows.Input;
    using System.Windows;
    
    namespace WpfApplication
    {
        public partial class TestClass
        {
            private void OnDoubleClick(object obj, MouseButtonEventArgs args)
            {
                MessageBox.Show("Double clicked!");
            }
        }
    }
