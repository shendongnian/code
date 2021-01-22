    var languages = new string[2];
    languages[0] = "English";
    languages[1] = "German";
    
    DataSet myDataSet = new DataSet();
    
    // --- Preparation
    DataTable lTable = new DataTable("Lang");
    DataColumn lName = new DataColumn("Language", typeof(string));
    lTable.Columns.Add(lName);
    
    for (int i = 0; i < languages.Length; i++)
    {
        DataRow lLang = lTable.NewRow();
        lLang["Language"] = languages[i];
        lTable.Rows.Add(lLang);
    }
    myDataSet.Tables.Add(lTable);
    
    toolStripComboBox1.ComboBox.DataSource = myDataSet.Tables["Lang"].DefaultView;
    toolStripComboBox1.ComboBox.DisplayMember = "Language";
    toolStripComboBox1.ComboBox.BindingContext = this.BindingContext;
