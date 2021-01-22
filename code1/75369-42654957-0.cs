    using System.Data.SqlClient;
    namespace MyDB.DataTableAdapters
    {
        public partial class XTableAdapter
        {
            public void SetTimeout(int seconds)
            {
                foreach (SqlCommand cmd in CommandCollection)
                {
                    cmd.CommandTimeout = seconds;
                }
            }
        }
    }
