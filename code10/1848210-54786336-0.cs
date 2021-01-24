    [Fact]
        public void Test1()
        {
            
            var employee = new Employee
            {
                AddressEmployee = new Address
                {
                    City = "SomeCity"
                }
            };
            
            //initialize automapper and register mapping profile
            var mockMapper = new MapperConfiguration(cfg => cfg.AddProfile(new EmployeeProfile()));
            
            //create new mapper
            var mapper = mockMapper.CreateMapper();
            
            //map
            var employeeModel = mapper.Map<EmployeeModel>(employee);
            
            // do assert or another stuff
        }
