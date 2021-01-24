    DataGridView grd = new DataGridView();
                grd.Columns.Add("Id", "Id");
                grd.Columns.Add("citemName", "Item Name");
                grd.Columns.Add("dExipryDate", "Expires On");
    
    
                grd.Rows.Add("1", "Soap", "21 august 2018");
                grd.Rows.Add("2", "Soap2", "21july 2018");
                grd.Rows.Add("3", "Soap3", "30 august 2018");
                grd.Rows.Add("4", "Soap4", "27 june 2018");
                grd.Rows.Add("5", "Soap5", "21 march 2018");
                grd.Rows.Add("6", "Soap6", "28 september 2018");
                grd.Rows.Add("7", "Soap7", "23 october 2018");
    
    
    
                foreach (DataGridViewRow drow in grd.Rows)            {
    
                    DateTime expdate = DateTime.Parse(drow.Cells["dExipryDate"].Value.ToString());
    
                    TimeSpan tmspn = expdate - DateTime.Now.Date;
                    if (tmspn.Days < 7 && tmspn.Days >0)
                    {
                        //tmspn.Days >0 if you want to show already expired item 
                        MessageBox.Show(drow.Cells["dExipryDate"].Value.ToString() + "Will Expire in " + tmspn.Days + "Days");
                    }
    
                }
