            System.Data.Common.DbConnectionStringBuilder builder = new System.Data.Common.DbConnectionStringBuilder();
            
            builder.ConnectionString = "Provider=\"Some;Provider\";Initial Catalog='Some;Catalog';";
            
            foreach (string key in builder.Keys)
            {
                Response.Write(String.Format("{0}: {1}<br>", key , builder[key]));
            }
