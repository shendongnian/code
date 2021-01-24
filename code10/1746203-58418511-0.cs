        [TestMethod]
        public void GetProviderSpecificDataType()
        {
            using (SqlConnection connection = new SqlConnection("Server=(localdb)\\v11.0;Integrated Security=true;"))
            {
                connection.Open();
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "select * from [TestDb].[dbo].[Table]";
                SqlDataReader reader = cmd.ExecuteReader();
                DataTable table = reader.GetSchemaTable();
                var columnTypes = GetColumnTypes(table);
                Assert.AreEqual("SqlInt32", columnTypes["Id"]);
                Assert.AreEqual("SqlDecimal", columnTypes["Number"]);
                Assert.AreEqual("SqlMoney", columnTypes["Dollars"]);
            }
        }
        private Dictionary<string, string> GetColumnTypes(DataTable table)
        {
            Dictionary<string, string> data = new Dictionary<string, string>();
            foreach (DataRow row in table.Rows)
            {
                string columnName = row["ColumnName"].ToString();
                string dataType = ((Type)row["ProviderSpecificDataType"]).Name;
                data[columnName] = dataType;
            }
            return data;
        }
