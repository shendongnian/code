      string strDate = string.Empty;
      if(ACCOUNT_ESTABLISHED_DATE != null)
      {
      strDate = ACCOUNT_ESTABLISHED_DATE.Value.ToString("yyyy-MM-dd");
     }
      or you can use null collacing operator
      DateTime newDate  = ACCOUNT_ESTABLISHED_DATE ?? new Date();
       newDate.ToString("yyyy-MM-dd");
