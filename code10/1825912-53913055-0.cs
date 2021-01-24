       public class Customer
        {
            public int CustomerId { get; set; }
            public string Name { get; set; }
            public string Address1 { get; set; }
            public string Address2 { get; set; }
            public string Address3 { get; set; }
    
    
            public Customer Clone()
            {
                // where the reference is not detached
                var employee1 = new Customer
                {
                    Name = Name,
                    Address1 = Address1,
                    Address2 = Address2,
                    Address3 = Address3
                };
    
                // with reference detached
                var serialisedData = JsonConvert.SerializeObject(this);
                var employee2 = JsonConvert.DeserializeObject<Employee>(serialisedData);
    
                //  return employee1 or employee2;
                return employee1;
    
            }
        }
   
