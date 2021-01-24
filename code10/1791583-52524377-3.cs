    // Outside foreach loop (better make it a class field and initialize this
    // inside the class constructor)
    DBConnection db = new DBConnection(connectionString);
    // Inside foreach loop
    DataTable result = db.NonQuery("INSERT INTO NStacks(NStacksName, NStacksItem)VALUES(@NStacksName, @NStacksItem)",
        new SqlCeParameter("NStacksName", textBox1.Text),
        new SqlCeParameter("NStacksItem", File));
