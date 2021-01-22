    public static SortedList<string, string> GetCountries(string conn)
            {
                var dict = new SortedList<string, string>();
                dict.Add("","Select One");
                var sql = "SELECT [CountryID]      ,[Descr]  FROM [dbo].[Countries] Order By CountryID ";
                using (var rd = GetDataReader(conn, sql))
                {
                    while (rd.Read())
                    {
                        dict.Add(rd["Descr"].ToString(), rd["CountryID"].ToString());
                    }
                }
                return dict;
            }
    
    Dim List As SortedList(Of String, String) = VDB.CoreLib.DbUtils.GetCountries(connDB)
    
            ddlBankCountry.DataSource = List
            ddlBankCountry.DataTextField = "Key"
            ddlBankCountry.DataValueField = "Value"
            ddlBankCountry.DataBind()
