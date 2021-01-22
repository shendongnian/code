           var persons = new[] {new {name = "aaa", salary = 40000}, 
                         new  {name = "aaa", salary = 40000}, 
                         new  {name = "aaa", salary = 40000}, 
                         new  {name = "aaa", salary = 40000}};
        GridView1.DataSource = persons;
        GridView1.AutoGenerateColumns = false;
        var NameField = new BoundField();
        NameField.HeaderText = "Name";
        NameField.DataField = "name";
        GridView1.Columns.Add(NameField);
        var SalaryField = new BoundField();
        SalaryField.HeaderText = "Salary";
        SalaryField.DataField = "salary";
        SalaryField.DataFormatString = "{0:c2}";
        SalaryField.HtmlEncode = false;
        GridView1.Columns.Add(SalaryField);
        GridView1.DataBind();
