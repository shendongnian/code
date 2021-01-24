    void LoadData()
    {
        List<Person> data = new List<Person>();
        Person p = new Person { Id = 1, Age = 20, Job = "Consultant", Name = "John" };
        Person p2 = new Person { Id = 2, Age = 22, Job = "Programmer", Name = "Steven" };
        Person p3 = new Person { Id = 3, Age = 22, Job = "Manager", Name = "Alice" };
        Person p4 = new Person { Id = 4, Age = 30, Job = "Analytic", Name = "Mark" };
        Person p5 = new Person { Id = 5, Age = 32, Job = "Analytic", Name = "Gregory" };
        Person p6 = new Person { Id = 6, Age = 32, Job = "Tester", Name = "Hugh" };
        data.Add(p);
        data.Add(p2);
        data.Add(p3);
        data.Add(p4);
        data.Add(p5);
        data.Add(p6);
        bs = new BindingSource();
        bs.DataSource = data;
        dataGridView1.DataSource = bs;
    }
