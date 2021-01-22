    //Definition   
         public static DateTime ConvertPlainStringToDatetime(string Date, string inputFormat, string  outputFormat)
                {
                    DateTime date;
                    CultureInfo enUS = new CultureInfo("en-US");
                    DateTime.TryParseExact(Date, inputFormat, enUS,
                                        DateTimeStyles.AdjustToUniversal, out date);
            
                    string formatedDateTime = date.ToString(outputFormat);
                    return Convert.ToDateTime(formatedDateTime);   
                }
    //Calling
        
        string oFormat = "yyyy-MM-dd HH:mm:ss";
        DateTime requiredDT = ConvertPlainStringToDatetime("20190205","yyyyMMddHHmmss", oFormat  );
        DateTime requiredDT = ConvertPlainStringToDatetime("20190508-12:46:42","yyyyMMdd-HH:mm:ss", oFormat);
 
  
