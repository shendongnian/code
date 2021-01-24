    string datasource = DatasourceTb.Text;  // get value from user input.
    string catalog = "MyDB";
    string username = "myuser";
    string password = "mypass";
    string connectionString = 
        String.Format("Data Source={0}; Initial Catalog={1}; User Id={2}, Password={3};",                           
                            datasource,
                            catalog,
                            username,
                            password
                        );
