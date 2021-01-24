     you need to define your property like below
          
       public ISalary _salary { get; set; }
     
      Then the below code will work for you
   
           var build = new ContainerBuilder();
            // build.RegisterType<Salary>().As<ISalary>();
            build.RegisterType<Salary>().As<ISalary>();
            build.RegisterType<Employee>().As<IEmployee>().InstancePerLifetimeScope()
             .PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            var container = build.Build();
            IEmployee employee = container.Resolve<IEmployee>();
            Console.WriteLine(employee.GetSalary(5));
            Console.ReadLine();
