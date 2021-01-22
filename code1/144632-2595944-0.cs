    System.Data.DataTable dtOut = dsOut
                                       .Tables
                                       .Cast<System.Data.DataTable>()
                                       .FirstOrDefault(t => t.TableName.Equals(grp)) 
                                     ?? RptTable(grp);
