    public class CustomerService<T> where T : class
        {    
            public static Customer CreateCustomer(T data)
            {
                Customer customer = new Customer();
    
                if (typeof(T) == typeof(Student))  //We just check here is data comes from api is of type Student
                {
                    Student student = (Student)(object)data; //then cast this data to Student
    
                    customer = new Customer()
                    {
                        CustomerNo = student.StudentID, // Convert.ToInt32(student.StudentID),
                        CustomerName = student.FirstName,
    
                        //Assign all your remaining customer properties with desired values
                        CustomerContact = new CustomerContact()
                        {
                            CustomerContactName = "Test",
                            CustomerContactEmail = "test@test.com",
                            CustomerContactPhone = "011111111"
                        },
                        PrimaryAddress = new CustomerAddress()
                        {
                            Street = "Hill street",
                            ZipCode = "16962",
                            City = "New york",
                            Country = "USA"
                        },
                        BillingAddress = new CustomerAddress()
                        {
                            Street = "Hill street",
                            ZipCode = "16962",
                            City = "New york",
                            Country = "USA"
                        }
                    };
                }
    
                if (typeof(T) == typeof(Teacher))  //We just check here is data comes from api is of type Teacher
                {
                    Teacher teacher = (Teacher)(object)data; //then cast this data to Teacher 
    
                    customer = new Customer()
                    {
                        CustomerNo =  teacher.TeacherID,  // Convert.ToInt32(teacher.TeacherID),
                        CustomerName = teacher.FirstName,
    
                        //Assign all your remaining customer properties with desired values
                        CustomerContact = new CustomerContact()
                        {
                            CustomerContactName = "Test",
                            CustomerContactEmail = "test@test.com",
                            CustomerContactPhone = "011111111"
                        },
                        PrimaryAddress = new CustomerAddress()
                        {
                            Street = "Hill street",
                            ZipCode = "16962",
                            City = "New york",
                            Country = "USA"
                        },
                        BillingAddress = new CustomerAddress()
                        {
                            Street = "Hill street",
                            ZipCode = "16962",
                            City = "New york",
                            Country = "USA"
                        }
                    };
                }
    
    
                return customer;
            }
    
    
        }
