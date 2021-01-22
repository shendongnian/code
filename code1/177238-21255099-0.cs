    textBox1.AutoCompleteCustomSource = LoadAutoComplete(); //this method is below
    textBox1.AutoCompleteMode = AutoCompleteMode.Suggest;
    textBox1.AutoCompleteSource = AutoCompleteSource.CustomSource;
    
    public static AutoCompleteStringCollection LoadAutoComplete()
    {
       DataTable dt = LoadDataTable(); //suppose this method returns a DataTable with fetched records from database.
       AutoCompleteStringCollection stringCol = new AutoCompleteStringCollection();
       foreach (DataRow row in dt.Rows)
       {
          stringCol.Add(Convert.ToString(row[0]));
       }
       return stringCol; //return the string collection with added records
    }
