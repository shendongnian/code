        if(!IsPostBack)
       {
         DropDownList1.Items.Clear()
         DropDownList1.Items.Insert(0, new ListItem("Select Category"));
         SqlDataReader dr = DAL.ExecuteReaderDemo("select * from addcategory");
      while (dr.HasRows)
          {
            dr.Read();
     DropDownList1.Items.Insert(1, new ListItem(dr[1].ToString(),dr[0].ToString()));
           }
             dr.Close();
     }
