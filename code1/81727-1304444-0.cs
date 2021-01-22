      DataTable dt=new DataTable();
      dt.Columns.Add("Col1",typeof(int));
      dt.Columns.Add("Col2",typeof(String));
      dt.Rows.Add(1,"A");
      dt.Rows.Add(2,"B");
      
       comboBox1.DataSource = dt;
       comboBox1.DisplayMember = "Col2";
       comboBox1.ValueMember = "Col1";
