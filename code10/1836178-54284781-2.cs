    var build = new ContainerBuilder();
    // build.RegisterType<Salary>().As<ISalary>();
    build.RegisterType<Salary>().As<ISalary>();
    build.RegisterType<Employee>().As<IEmployee>().PropertiesAutowired();
    var container = build.Build();
    IEmployee employee = container.Resolve<IEmployee>();
    Console.WriteLine(employee.GetSalary(5));
    Console.ReadLine();
