                        if (isErrorRow)
                        {                           
                            //nr is the NewRow for dt1
                            var nr2 = dt2.NewRow();
                            nr2.ItemArray = nr.ItemArray;
                            dt2.Rows.Add(nr2);
                        }
