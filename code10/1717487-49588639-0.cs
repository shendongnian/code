     private void Form1_Load(object sender, EventArgs e)
            {
                DataTable table = new DataTable();
                table.Columns.Add("id", typeof(string));
                table.Columns.Add("start_date", typeof(DateTime));
                table.Columns.Add("DateField", typeof(string), "id + ' : ' + start_date");
                DateTime test = new DateTime(2018, 03, 20);
                table.Rows.Add("123", test);
                comboBox1.DataSource = table;
                comboBox1.DisplayMember = "DateField";
          // tried to make your datasource here.
            }
    
            private void comboBox1_Format(object sender, ListControlConvertEventArgs e)
            {
                DateTime date = (DateTime)((DataRowView)e.ListItem).Row["start_date"];
                //found start_date in itemarray. 
                string id = ((DataRowView)e.ListItem).Row["id"].ToString();
                // found id in item array
                string formatValue = date.AddDays(11).ToShortDateString();
                // i added also 11 days to see if the actual date is changing
                e.Value = id + " : " + DateTime.ParseExact(formatValue, "dd/MM/yyyy",  new CultureInfo("tr-TR"));
                // then combined both values, and formatted the datetime as you desired.
         
            }
