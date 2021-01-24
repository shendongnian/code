    string querySql = "SELECT *query here* WHERE FirmClientStaffAssignmentName = 'Primary Partner' AND ClientSubId = @ClientSubId" +
                      " UNION SELECT *query here* WHERE FirmClientStaffAssignmentName = 'Primary Partner' AND ClientSubId = @UnionClientSubId";
    using (SqlConnection con = new SqlConnection("Data Source = *******"))
    {
        using (SqlCommand cmdSql = new SqlCommand(querySql, con))
        {
            cmdSql.Parameters.Add("@ClientSubId", SqlDbType.VarChar).Value = SearchBox.Text;
            cmdSql.Parameters.Add("@UnionClientSubId", SqlDbType.VarChar).Value = SearchBox.Text;
            using (SqlDataAdapter sda = new SqlDataAdapter(cmdSql)
            {
                sda.Fill(yourDataTable);
            }
        }
    }
