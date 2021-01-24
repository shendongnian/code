     public IHttpActionResult GetCustomer()
        {
            Teacher teacher = new Teacher { TeacherID = 12, FirstName = "Vijay" };
            Customer customer1 = CustomerService<Teacher>.CreateCustomer(teacher);            
            return Ok(customer1);
        }
