    using System.Windows;
    using System.Collections.ObjectModel;
    using System;
    
    namespace TestStringFormat234
    {
        public partial class Window1 : Window
        {
            public Window1()
            {
                InitializeComponent();
            }
        }
    
        //view model
        public class CustomerViewModel
        {
            public ObservableCollection<Customer> GetAllCustomers {
                get {
                    ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
                    customers.Add(new Customer { FirstName = "Jim", LastName = "Smith", HireDate = DateTime.Parse("2007-12-31") });
                    customers.Add(new Customer { FirstName = "Jack", LastName = "Jones", HireDate = DateTime.Parse("2005-12-31") });
                    return customers;
                }
            }
        }
    
        //model
        public class Customer
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime HireDate { get; set; }
        }
    }
