    // using System.Globalization;
    SqlCommand cm = new SqlCommand("SELECT 12345.678 as decimal");
    // ...
    SqlDataReader dr = cm.ExecuteReader();
    if(dr.Read())
    {
        string value = dr.GetValue(0).ToString()
            .Replace(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator, "")
    }
