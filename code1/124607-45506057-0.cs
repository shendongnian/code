     public List<T> updateSiteDetails<T>(int SiteId, int CategoryId, string[] values)
        {
            int temp = values.Count();
            int Counter = 0;
            List<T> SiteDetails = null;
            var parameterData = new string[temp];
            var para = new string[temp];
            foreach (string value in values)
            {
                Counter =Counter++;
                parameterData[Counter] = "@,value"+Counter;
                para[Counter] = string.Format(","+value);
            }
            //string ParameterDatas=string.Join(",",parameterData);
            string parameterValue = string.Join(",",para);
            using (SBDEntities db = new SBDEntities())
            {
                SiteDetails = db.Database.SqlQuery<T>("Sp_Update_Data @SiteId,@CategoryId" + string.Join(",", parameterData),string.Join(",",para)
                       //new Object[] { new SqlParameter("@SiteId", SiteId),
                      // new SqlParameter("@CategoryId",CategoryId)}
            ).ToList();
                }
                return SiteDetails;
            }     
