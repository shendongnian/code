    private string CreateSqlFilter(string fieldName, Control userInputControl, SqlCommand command, bool exactMatch)
    {
        string searchValue = null;
        if (userInputControl is TextBox) searchValue = ((TextBox)userInputControl).Text;
        if (userInputControl is ComboBox) searchValue = ((ComboBox)userInputControl).Text;
        if (String.IsNullOrWhiteSpace(searchValue)) return null;
    
        if (exactMatch)
        {
            command.Parameters.Add(new SqlParameter("@" + fieldName, searchValue));
            return fieldName + " = @" + fieldName;
        }
        else
        {
            command.Parameters.Add(new SqlParameter("@" + fieldName, "%" + searchValue + "%"));
            return fieldName + " LIKE @" + fieldName;
        }
    }
    
    private void button2_Click(object sender, EventArgs e)
    {
        SqlCommand selectCommand = new SqlCommand();
    
        var filterConditions = new[] {
            CreateSqlFilter("Name_Arabic", txtName_Arabic, selectCommand, false),
            CreateSqlFilter("gender", CBgender, selectCommand, false),
            CreateSqlFilter("CIVILIDD", txtCIVILIDD, selectCommand, true),
            CreateSqlFilter("NATIONALITY", cbNationality, selectCommand, false)
            // etc.
        };
    
        string filterCondition = filterConditions.Any(a => a != null) ? filterConditions.Where(a => a != null).Aggregate((filter1, filter2) => String.Format("{0} AND {1}", filter1, filter2)) : (string)null;
    
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myDatabase"].ConnectionString))
        {
            selectCommand.Connection = connection;
            selectCommand.CommandText = filterCondition == null ? "SELECT * FROM tabl1" : "SELECT * FROM tabl1 WHERE " + filterCondition;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            DataTable dataSource = new DataTable();
            adapter.Fill(dataSource);
            dataGridView1.DataSource = dataSource;
        }
    }
