    private readonly List<Employee> shopEmployee = new List<Employee>();
    public void Enter(object employee)
    {
        if (employee is Employee e)
        {
            shopEmployee.Add(e);
            Console.WriteLine($"{e.Id} has entered the shop");
        }
    }
