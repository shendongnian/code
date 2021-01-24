    static void Main(string[] args)
    {
        var build = new ContainerBuilder();
        build.Register<EmployeeDetail>().As<IEmployeeDetail>().InstancePerDepenency();
        build.Register<Employee>().AsSelf().InstancePerDependency();
        var container = build.Build();
        Employee employee = container.Resolve<Employee>();
        Console.WriteLine(employee.GetName());
        Console.ReadLine();
    }
