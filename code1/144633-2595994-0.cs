                ...program...
                {
                   System.Data.DataTable dtOut = GetDataTableByName(grp, dsOut);
                }
                public DataTable GetDataTableByName(string grp, object dsOut)
                {
                  foreach (System.Data.DataTable d1 in dsOut.Tables)
                    {                    
                       if (d1.TableName.Equals(grp))
                         return RptTable(grp)
                    }
                  return null;
                }
