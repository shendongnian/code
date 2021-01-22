                }
                else
                {connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source='" + path + "';" + "Extended Properties='HTML Import;IMEX=1;HDR=No;'";
                   
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return connStr;
        }
}
