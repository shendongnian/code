    // call upon startup to get all the data one time
    private void GetData()
    {
        DataTable dataSource = new DataTable();
        using (var connection = new SqlConnection(ConfigurationManager.ConnectionStrings["myDatabase"].ConnectionString))
        {
            connection.Open();
            SqlCommand selectCommand = new SqlCommand("SELECT * FROM tabl1", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(selectCommand);
            adapter.Fill(dataSource);
            dataGridView1.DataSource = dataSource;
        }
    }
    
    // create a filter for the given field in the database and our control
    private string CreateFilter(string fieldName, Control userInputControl, bool exactMatch)
    {
        string searchValue = null;
        if (userInputControl is TextBox) searchValue = ((TextBox)userInputControl).Text;
        if (userInputControl is ComboBox) searchValue = ((ComboBox)userInputControl).Text;
        if (String.IsNullOrWhiteSpace(searchValue)) return null;
        if (exactMatch)
            return String.Format("{0}='{1}'", fieldName, searchValue);
        return String.Format("{0} LIKE '%{1}%'", fieldName, searchValue);
    }
    
    // set the filter on our data grid view
    private void button1_Click(object sender, EventArgs e)
    {            
        var filterConditions = new[] {
            CreateFilter("Name_Arabic", txtName_Arabic, false),
            CreateFilter("gender", CBgender, false),
            CreateFilter("CIVILIDD", txtCIVILIDD, true),
            CreateFilter("NATIONALITY", cbNationality, false)
            // etc.
        };
                           
        var dataSource = (DataTable)dataGridView1.DataSource;
        if (!filterConditions.Any(a => a != null))
        {
            dataSource.DefaultView.RowFilter = null;
            return;
        }
    
        dataSource.DefaultView.RowFilter = filterConditions
            .Where(a => a != null)
            .Aggregate((filter1, filter2) => String.Format("{0} AND {1}", filter1, filter2));
    }
