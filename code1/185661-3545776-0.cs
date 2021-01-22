    namespace DataGridTest
    {
        using System.Collections.Generic;
        using System.Windows;
    
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                Customers = this.GetCustomers();
                DataContext = this;
            }
    
            private IEnumerable<Customer> GetCustomers()
            {
                yield return new Customer() { Name = "first" };
                yield return new Customer() { Name = "second" };
                yield return new Customer() { Name = "third" };
            }
    
            public IEnumerable<Customer> Customers
            {
                get;
                set;
            }
        }
    
        public class Customer
        {
            public string Name
            {
                get;
                set;
            }
        }
    }
