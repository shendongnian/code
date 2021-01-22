    namespace CodeSamples.DAL
    {
        public static class DAL
        {
            public static CustomerList GetCustomerList(string SortExpression)
            {
                return GetCustomerList(int.MaxValue, 0, SortExpression);
            }
    
            public static CustomerList GetCustomerList()
            {
                return GetCustomerList(int.MaxValue, 0,String.Empty);
            }
    
            public static CustomerList GetCustomerList(int maximumRows, int startRowIndex, string SortExpression)
            {
                const string query = "Select * from Customers";
                CustomerList customers = new CustomerList();
    
    
                SqlConnection conn = new SqlConnection("Data Source=Win2k8;Initial Catalog=NorthWind;User ID=sa;Password=XXXXX");
                SqlCommand command = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = command.ExecuteReader();
    
                ArrayList rows = new ArrayList();
    
                while (reader.Read())
                {
                    object[] values = new object[reader.FieldCount];
                    reader.GetValues(values);
                    rows.Add(values);
                }
    
                conn.Close();
    
                int currentIndex = 0;
                int itemsRead = 0;
                int totalRecords = rows.Count;
    
                foreach (object[] row in rows)
                {
                    if (currentIndex >= startRowIndex && itemsRead <= maximumRows)
                    {
                        customers.Add(new Customer { Name = row[1].ToString(), ID = row[0].ToString(), ContactName = row[2].ToString() });
                        itemsRead++;
                    }
                    currentIndex++;
                }
    
    
                CustomerList sortedCustomers = new CustomerList();
    
                if (SortExpression == "ContactName")
                {
                    var sortedList = from Customer customer in customers
                                     orderby (customer.ContactName)
                                     select customer;
                    foreach (Customer x in sortedList)
                    {
                        sortedCustomers.Add(x);
                    }
                }
    
                if (SortExpression == "ID")
                {
                    var sortedList = from Customer customer in customers
                                     orderby (customer.ID)
                                     select customer;
                    foreach (Customer x in sortedList)
                    {
                        sortedCustomers.Add(x);
                    }
                }
                
                if (SortExpression == "")
                {
                    var sortedList = from Customer customer in customers
                                     orderby (customer.Name)
                                     select customer;
                    foreach (Customer x in sortedList)
                    {
                        sortedCustomers.Add(x);
                    }
                }
    
                return sortedCustomers;
            }
        }  
    
        public class CustomerList : List<Customer>
        {
    
        } 
    
        public class Customer
        {
            public Customer()
            {
            }
    
            public Customer(string Name, string id)
            {
                this.Name = Name;
                ID = id;
            }
            public string ID
            {
                get;
                set;
            }
    
            public string Name
            {
                get;
                set;
            }
    
            public string ContactName
            {
                get;
                set;
            }
    
    
        }
    }
