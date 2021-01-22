    public void CompareLastSentDate()
    {
       DateTime LastEmailSentDate = //get the field from the LastEmailSentDate field in the  database as i mention before
    
       int sendEmailPeriod =  // get the field from the SendEmailPeriod of the user field from database
    
       DateTime DatePeriod = new DateTime(DateTime.Now.Year, DateTime.Now.Month, (DateTime.Now.Day - sendEmailPeriod ));
    
       if(LastEmailSentDate.Day <= DatePeriod.Day)
       {
          // sent the email to the user
       }
    
    }
