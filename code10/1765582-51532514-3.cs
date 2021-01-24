     public IHttpActionResult GetCustomer()
        {           
            Student student = new Student { StudentID = 11, FirstName = "Kunal" };
            Customer customer2 = CustomerService<Student>.CreateCustomer(student);
            return Ok(customer2);
        }
