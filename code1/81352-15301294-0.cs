       tc = new TableCell();
       dd= new DropDownList();
       ddl.ID = dd1;
       foreach (DataRow dr in dst.Tables[0].Rows)
       {
          ddl.Items.Add(new ListItem(dr["Text"].ToString(),dr["Value"].ToString()));
       }
       tcActions.Controls.Add(ddlActions);
