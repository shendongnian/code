        var command = new SQLiteCommand("SELECT * FROM employees; SELECT * FROM holidays");
        var connection=new SQLiteConnection(@"data source=C:\employees.db");
        command.Connection = connection;
        SQLiteDataAdapter adapter = new SQLiteDataAdapter(command);
        DataSet d = new DataSet();
        adapter.Fill(d);                        
        DataTable employees = d.Tables[0];
        // [...]
        // here I'm databinding my textboxes etc. to various columns 
        // of the employees data table - this works fine, navigation works well etc.
        // [...]
        DataTable holidays = d.Tables[1];
        DataRelation relation;
        DataColumn master = employees.Columns["id"];
        DataColumn slave = holidays.Columns["employeeid"];
        relation = new DataRelation("relation", master, slave);
        d.Relations.Add(relation);
        listBox1.DisplayMember = "table.relation.start"; // <= it wouldn't look good like that of course, but I just want to get the thing to work for now
        listBox1.DataSource = d;
