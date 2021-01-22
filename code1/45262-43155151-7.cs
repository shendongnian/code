    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Data;
    using System.Data.SqlClient;
    using DAL;
    namespace BLL
    {
        public static class BLL
        {
    
    
            public static int InsertUser(string lastid, params SqlParameter[] coll)
            {
    
    
                int lastInserted = 0;
    
    
                SqlCommand comm = new SqlCommand();
    
                comm.Connection = DAL.DAL.conn;
    
    
                foreach (var param in coll)
                {
    
                    comm.Parameters.Add(param);
    
                }
    
                SqlParameter lastID = new SqlParameter();
                lastID.ParameterName = lastid;
                lastID.SqlDbType = SqlDbType.Int;
                lastID.Direction = ParameterDirection.ReturnValue;
    
                comm.Parameters.Add(lastID);
    
                comm.CommandType = CommandType.StoredProcedure;
    
                comm.CommandText = "InsertNewUser";
    
                comm.ExecuteNonQuery();
    
                lastInserted = (int)comm.Parameters[lastid].Value;
    
                return lastInserted;
    
            }
    
    
    
    
    
        }
    }
