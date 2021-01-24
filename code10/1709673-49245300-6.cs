                //set start and end date
                DateTime fromThisDate = new DateTime(2015, 02, 21, 0, 0, 0);
                DateTime toThisDate = new DateTime(2017, 02, 21, 0, 0, 0);
    
                int indexOfMaximumAge = -1;
                int currentMaximumAge = -1;
    
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (row.Cells[1].Value != null) // Need to check for null if new row is exposed
                    {
                        //filter by date range
                        //convert
                        DateTime cellDate = Convert.ToDateTime(row.Cells[1].Value); 
                        if ((cellDate > fromThisDate) & (cellDate < toThisDate))
                        {
                            //find max
                            //convert
                            int cellAge = Convert.ToInt16(row.Cells[3].Value);
                            if (cellAge > currentMaximumAge)
                            {
                                currentMaximumAge = cellAge;
                                indexOfMaximumAge = row.Index;
                            }
                        }
                    }
                }
