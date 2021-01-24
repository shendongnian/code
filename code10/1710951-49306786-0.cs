    Employee e = new Employee(name, salary);
    Bonus b = new Bonus(amount);
    g = g.AddNode(e);
    g = g.AddNode(b);
    g = g.AddEdge(e, b, "Bonus");
    g = g.AddEdge(b, e, "Employee");
