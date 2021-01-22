        private static System.Data.DataTable ObjectArrayToDataTable(object[] data)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
            // if data is empty, return an empty table
            if (data.Length == 0) return dt;
            Type t = data[0].GetType();
            System.Reflection.PropertyInfo[] piList = t.GetProperties();
            foreach (System.Reflection.PropertyInfo p in piList)
            {
                dt.Columns.Add(new System.Data.DataColumn(p.Name, p.PropertyType));
            }
            object[] row = new object[piList.Length];
            foreach (object obj in data)
            {
                int i = 0;
                foreach (System.Reflection.PropertyInfo pi in piList)
                {
                    row[i++] = pi.GetValue(obj, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }
        internal static DataTable GetAllStoredFileDetailsByUserID(int userID)
        {
            var db = GetDataContext();
            object[] result;
            try
            {
                result = (from files in db.Files
                          where files.OwnerUserID == userID && files.IsThumbnail == false
                          select new
                          {
                              FileID = files.FileID,
                              Name = files.Name,
                              DateCreated = files.DateCreated,
                              Size = files.Size,
                              FileHits = (from act in db.FileWebActivities where act.FileID == files.FileID select act).Count()
                          }).ToArray();
            }
            catch (Exception)
            {
               //omitted
            }
            return ObjectArrayToDataTable(result);
        }
