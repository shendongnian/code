        foreach (DataRow row in tlds.Rows)
                    {
                        date = row["releaseDate"].ToString();
                        price = Convert.ToDouble(row["price"]);
                        tags = row["tags"].ToString();
        
                         TableRow row = new TableRow();
    
                         TableCell TLIdCell= new TableCell();
                         TLIdCell.Text = Convert.ToInt32(row["tldID"]);
                         row.Cells.Add(TLIdCell);
    
                          TableCell tldNameCell = new TableCell();
                          tldNameCell .Text = Convert.ToString(row["tldName"]);
                          row.Cells.Add(tldNameCell);
                         //Similarly add code for date, price and tags cells
    
                          // Finally add row to table rows collection
                          myTable.Rows.Add(row);
                    } 
