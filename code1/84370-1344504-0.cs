           Dim persons() = {New With {.name = "aaa", .salary = 40000}, _
                         New With {.name = "aaa", .salary = 40000}, _
                         New With {.name = "aaa", .salary = 40000}, _
                         New With {.name = "aaa", .salary = 40000}}
        GridView1.DataSource = persons
        GridView1.AutoGenerateColumns = False
        Dim NameField As New BoundField
        NameField.HeaderText = "Name"
        NameField.DataField = "name"
        GridView1.Columns.Add(NameField)
        Dim SalaryField As New BoundField
        SalaryField.HeaderText = "Salary"
        SalaryField.DataField = "salary"
        SalaryField.DataFormatString = "{0:c2}"
        SalaryField.HtmlEncode = False
        GridView1.Columns.Add(SalaryField)
        GridView1.DataBind()
