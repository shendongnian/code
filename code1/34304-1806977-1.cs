    StringCollection idCollection = new StringCollection();
    string strID = string.Empty;
    
    for (int i = 0; i < GridView1.Rows.Count; i++)
    {
       CheckBox chkDelete = (CheckBox) GridView1.Rows.Cells[0].FindControl("chkSelect");
       if (chkDelete != null)
       {
         if (chkDelete.Checked)
          {
              strID = GridView1.Rows.Cells[1].Text;
             idCollection.Add(strID);
        }
      }
    } 
