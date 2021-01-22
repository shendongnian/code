    private SqlDbType GetDBType(System.Type theType)
    {
         System.Data.SqlClient.SqlParameter p1;
         System.ComponentModel.TypeConverter tc;
         p1 = new System.Data.SqlClient.SqlParameter();
         tc = System.ComponentModel.TypeDescriptor.GetConverter(p1.DbType);
         if (tc.CanConvertFrom(theType)) {
            p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
         } else {
            //Try brute force
            try {
               p1.DbType = (DbType)tc.ConvertFrom(theType.Name);
            }
            catch (Exception) {
               //Do Nothing; will return NVarChar as default
            }
         }
         return p1.SqlDbType;
    }
