    static System.Data.DataTable
    getDataTable ( System.Data.DataTable[] tables, String grp )
    {
        foreach (System.Data.DataTable d1 in tables)
            {
                string d1_name = d1.TableName;
                if (d1_name.Equals(grp))
                {
                    return d1;
                }
            }
        return null;
    }
