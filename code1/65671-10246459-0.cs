    Sorry for late answer  i think this will help in future who w'll get this error in ajax cascadedropdown for error 500 is solved for me this error because of changing parameter values for the binding method as clearly showed below
    
    ** Initially **
       
    public CascadingDropDownNameValue[] BindCountrydropdown(string value, string text)
        {
            SqlConnection concountry = new SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            concountry.Open();
            SqlCommand cmdcountry = new SqlCommand("select * from tbl_Countries", concountry);
            SqlDataAdapter dacountry = new SqlDataAdapter(cmdcountry);
            cmdcountry.ExecuteNonQuery();
            DataSet dscountry = new DataSet();
            dacountry.Fill(dscountry);
            concountry.Close();
            List<CascadingDropDownNameValue> countrydetails = new      List<CascadingDropDownNameValue>();
            foreach(DataRow dtrow in dscountry.Tables[0].Rows)
            {
                string CountryID = dtrow["IDCountry"].ToString();
                string CountryName = dtrow["CountryName"].ToString();
                countrydetails.Add(new CascadingDropDownNameValue(CountryName,CountryID));
            }
            return countrydetails.ToArray();
        }
      
    
    i got error 500 i found solution because of changing parmeter name in above method solution is given below u must pass parmaters as(knownCategoryValues,category) don't change parameter name
    
    ** Solution **
      public CascadingDropDownNameValue[] BindCountrydropdown(string knownCategoryValues, string category)
        {
            SqlConnection concountry = new  SqlConnection(ConfigurationManager.ConnectionStrings["Connection"].ConnectionString);
            concountry.Open();
            SqlCommand cmdcountry = new SqlCommand("select * from tbl_Countries", concountry);
            SqlDataAdapter dacountry = new SqlDataAdapter(cmdcountry);
            cmdcountry.ExecuteNonQuery();
            DataSet dscountry = new DataSet();
            dacountry.Fill(dscountry);
            concountry.Close();
            List<CascadingDropDownNameValue> countrydetails = new List<CascadingDropDownNameValue>();
            foreach(DataRow dtrow in dscountry.Tables[0].Rows)
            {
                string CountryID = dtrow["IDCountry"].ToString();
                string CountryName = dtrow["CountryName"].ToString();
                countrydetails.Add(new CascadingDropDownNameValue(CountryName,CountryID));
            }
            return countrydetails.ToArray();
        }
    
    i think this will help for u
