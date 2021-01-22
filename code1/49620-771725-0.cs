     private void DataLoad(DataSet d)
          { 
           DataView dv = d.Tables[0].DefaultView;
           dv.Sort = SortOrder;
           dgSearchResults.DataSource = dv;
           
 
           dgSearchResults.AutoGenerateColumns = false;
           dgSearchResults.BorderWidth = 3;
           if(dv.Table.Rows.Count > 0)
           {
                if(dgSearchResults.Columns.Count == 0)
                {
                     foreach(DataColumn dc in d.Tables[0].Columns)
                     {
                          BoundColumn bc = new BoundColumn();
                          bc.SortExpression = dc.ColumnName;
                          bc.ItemStyle.Wrap = false; 
                          bc.ItemStyle.BorderWidth = 2; 
                          bc.DataField  = dc.ColumnName; 
                          dgSearchResults.Columns.Add(bc);     
                     }
                     
                     bcButton.CommandName = "view";
                     bcButton.Text = "View Details";
                     bcButton.ButtonType = ButtonColumnType.PushButton;
                     dgSearchResults.Columns.Add(bcButton);
           
                     dgSearchResults.Columns[0].HeaderText = "Guid";
                     dgSearchResults.Columns[1].HeaderText = "Name";
                     dgSearchResults.Columns[2].HeaderText = "Phone";
                     dgSearchResults.Columns[3].HeaderText = "Email";
                     dgSearchResults.Columns[4].HeaderText = "Area";
                     dgSearchResults.Columns[5].HeaderText = "LocationID";
                     dgSearchResults.Columns[6].HeaderText = "Location";
                     dgSearchResults.AllowSorting = true;
           
                     //hide guid and location id
                     dgSearchResults.Columns[0].Visible = false;
                     dgSearchResults.Columns[5].Visible = false;
      
                }
           }
           else
           {
                lblMessage.Text = "No Results Found Matching Your Search.";
                lblMessage.Visible = true;
           }               
      }
