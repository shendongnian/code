            string version = "";
            int n = 0;
            using (DataSet ds = new DataSet())
            {
                ds.ReadXml(@"sample.xml");
                if(ds.Tables.Contains("ManagedObject") 
                   && ds.Tables["ManagedObject"].Rows.Count > n)
                {
                    ver = ds.Tables["ManagedObject"].Rows[n]["version"].ToString();
                }
            }
