    var builder = new ContainerBuilder();
    builder.RegisterType<Salary>().As<ISalary>();
    builder.RegisterType<Employee>()
        .OnActivated(IActivatedEventArgs<Employee> e) =>
        {
            var salary = e.Context.Resolve<ISalary>();
            e.Instance.SetSalary(salary);
        });
    var container = build.Build();
    Employee employee = container.Resolve<Employee>();
