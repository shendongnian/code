    Dictionary<int, List<Employee>> employees = new Dictionary<int, List<Employee>>();
    
    /* Here you will do the actual reading from DB */
    //             id,        name,      bossId
    employees.Add(666, "The Master     ", 0);
    employees.Add(123, "The Underling 1", 666);
    employees.Add(879, "The Underling 2", 666);
    employees.Add(001, "The Slave 1    ", 123);
    
    this.treeView1.BeginUpdate();
    PopulateTreeView(employees, 0, this.treeView1.Nodes);
    this.treeView1.EndUpdate();
