        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using SubSonic;
        namespace MyUtil.ExtensionMethods
        {
            public static class SubSonicSqlQueryExtensionMethods
            {
                public static List<String> ExecuteTypedList(this SqlQuery qry)
                {
                    List<String> list = new List<String>();
                    foreach (System.Data.DataRow row in qry.ExecuteDataSet().Tables[0].Rows)
                    {
                         list.Add((String)row[0]);
                    }
                    return list;
                }
            }
        }
