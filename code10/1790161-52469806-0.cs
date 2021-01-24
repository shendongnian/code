    int idForeignKey = inputIdFkey //Implemented on the WebPage for testing purposes
    List<int> intList = new List<int>();
    List<string> stringList = new List<string>();
    List<DateTime> dateList = new List<DateTime>();
    string oString = "Select * from Table where ForeignKey = @fKey";
    conn.Open();
    SqlCommand oCmdSleep = new SqlCommand(oString, conn);
    oCmdSleep.Parameters.AddWithValue("@fKey", idForeignKey);
    using (SqlDataReader oReader = oCmdSleep.ExecuteReader())
    {
        while (oReader.Read())
        {
            intList.Add(oReader.GetDateTime(0));
            dstringList.Add(oReader.GetDateTime(3));
            dateList.Add(oReader.GetDateTime(4));
        }
    }
    conn.Close();
