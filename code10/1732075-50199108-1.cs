    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Shapes;
    
    namespace TestingLayouts
    {
        /// <summary>
        /// Interaction logic for Window2.xaml
        /// </summary>
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
            }
    
    
    
    
          private void Button_Click_1(object sender, RoutedEventArgs e)
          {
             var data = new orderData { OrderID = "10248", CustomerID = "Test2", EmployeeID="5" };
    
             addDataItems.Items.Add(data);
          }
          public class orderData
          {
             public string OrderID { get; set; }
             public string CustomerID { get; set; }
             public string EmployeeID { get; set; }
          }
       }
    }
