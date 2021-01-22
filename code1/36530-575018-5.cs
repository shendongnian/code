    using System.Data.SqlClient;
    using System.Data;
    using System.Data.SqlTypes;
    using System.Xml;
    namespace TestConsole
    {
        class Program
        {
            static void Main(string[] args)
            {
                string xmlDoc = "<root><el1>Nothing</el1></root>";
                string connString = "server=(local);database=IntroDB;UID=sa;PWD=pwd";
                SqlConnection conn = new SqlConnection(connString);
                SqlCommand cmd = new SqlCommand("XmlTest_Insert", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@XmlText", SqlDbType.Xml);
                param.Value = new SqlXml(new XmlTextReader(xmlDoc
                               , XmlNodeType.Document, null));
                cmd.Parameters.Add(param);
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Dispose();
            }
        }
    }
