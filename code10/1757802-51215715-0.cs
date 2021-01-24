    class Test_Class 
    {
      Form1 form1 = null;                     // <==
      public void test(Form1 form1_)         // <==
      {
        form1 = form1_;                     // <==
        DataTable dt1 = new DataTable();
        dt1.Clear();
        dt1.Columns.Add("Name");
        dt1.Columns.Add("BDate");
        dt1.Rows.Add("Joh", 1997);
        dt1.Rows.Add("Keylor", 1995);
        form1.dataGridView2.DataSource = dt1;
      }
    }
