    var persons = new[] {new {name = "aaa", salary = 40000}, 
                     new  {name = "aaa", salary = 40000}, 
                     new  {name = "aaa", salary = 40000}, 
                     new  {name = "aaa", salary = 40000}};
    
    DataGridView1.AutoGenerateColumns = false;
    
    var NameField = new DataGridTextBoxColumn();
    
    NameField.HeaderText = "Name";
    NameField.DataPropertyName = "name";
    DataGridView1.Columns.Add(NameField);
    
    var SalaryField = new DataGridViewTextBoxColumn();
    SalaryField.HeaderText = "Salary";
    SalaryField.DataPropertyName = "salary";
    SalaryField.DefaultCellStyle.Format = "{0:c2}";
    DataGridView1.Columns.Add(SalaryField);
    
    DataGridView1.DataSource = persons;
