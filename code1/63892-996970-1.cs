    public IDataRecord GetXYZ(int id)
    {
        DataTable dt = new DataTable();
        using (var cn = getConnection())
        using (var cmd = new SqlCommand("getXYZ"))
        {
            cmd.CommandType = CommandTypes.StoredProcedure;
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = id;
            using (var rdr = cmd.ExecuteReader())
            {
               dt.Load(rdr);
            }
        }
        //obviously put a little more work into your error handling
        if (dt.Rows.Count <= 0)
           throw new Exception("oops");  
        return dt.Rows[0];
    }
 
    public class XYZFactory
    {
        public static XZY Create(IDataRecord row)
        {
            XYZ result = new XYZ();
            result.id = row["ID"];
            result.otherfield = row["otherfield"];
            return result;
        }
    }
    
