    namespace GenoTip.DAL
    {
        public interface IAccessorForSQL
        {
            bool Delete();
            bool Save(string sp, ListDictionary ld, CommandType cmdType);
            DataSet Select();
            bool Update();
        }
    
        public class _AccessorForSQL : IAccessorForSQL
        {
            private DataSet ds;
            private DataTable dt;
    
    
            public virtual bool Save(string sp, ListDictionary ld, CommandType cmdType)
            {
                SqlConnection con = null;
                SqlCommand cmd = null;
                SqlDataReader dr = null;
                try
                {
                    con = GetConnection();
                    cmd = new SqlCommand(sp, con);
                    con.Open();
                    cmd.CommandType = cmdType;
                    foreach (string ky in ld.Keys)
                    {
                        cmd.Parameters.AddWithValue(ky, ld[ky]);
                    }
                    dr = cmd.ExecuteReader();
                    ds = new DataSet();
                    dt = new DataTable();
                    ds.Tables.Add(dt);
                    ds.Load(dr, LoadOption.OverwriteChanges, dt);
                }
                catch (Exception exp)
                {
                    HttpContext.Current.Trace.Warn("Error in GetCustomerByID()", exp.Message, exp);
                }
                finally
                {
                    if (dr != null)
                    {
                        dr.Close();
                    }
                    if (con != null)
                    {
                        con.Close();
                    }
                }
                return (ds.Tables[0].Rows.Count > 0) ? true : false;
            }
    
            public abstract bool Update();
            public abstract bool Delete();
            public abstract DataSet Select();
    
            private static SqlConnection GetConnection()
            {
                string connStr = WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                var conn = new SqlConnection("");
                return conn;
            }
        }
    }
