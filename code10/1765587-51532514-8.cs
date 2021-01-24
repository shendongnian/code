     public IHttpActionResult GetCustomer()
        {
            Teacher teacher = new Teacher { TeacherID = 12, FirstName = "Vijay" };  //this teacher data comes from front end or from caller of this api
            Customer customer1 = CustomerService<Teacher>.CreateCustomer(teacher);            
            return Ok(customer1);
        }
