     if (dt.Rows.Count > 0)
            {
              Debug.WriteLine("\n Rows extracted."); // -> Error thrown here.
    
              Debug.WriteLine("\n Rows content:" + DateTime.ParseExact(dt.Rows[0][0].ToString(), "yyyy-MM-dd hh:mi:ss", CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None));
    
              con.Close();
              da.Dispose();
            }
