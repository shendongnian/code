        DataTable dt = new DataTable();
        dt.Columns.Add("EmployeeId", typeof(int));
        dt.Columns.Add("FirstName", typeof(string));
        dt.Columns.Add("LastName", typeof(string));
        dt.Columns.Add("Grade", typeof(int));
        // Here we add five DataRows.
        dt.Rows.Add(11, "John", "Smith", 9);
		dt.Rows.Add(92, "Sunita", "Mali", 7);
        dt.Rows.Add(2, "Anil", "Kumar", 4);
        dt.Rows.Add(5, "Mike", "Reb", 11);
        dt.Rows.Add(1, "Sunil", "Dev", 12);
		
       //your counter variable
		int i= 0;
		foreach(DataRow row in dt.Rows) {
          //use IndexOf method to check if it's the first row
		  if( dt.Rows.IndexOf(row) == 0) {
		    i++;//only first row causes increment of i
		  }
          if(dt.Rows.IndexOf(row) == (dt.Rows.Count -1)) {
           //its the last row of datatable
          }
		}
