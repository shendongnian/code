    var employ = GetEnqDetails(101);
    if (employ != null)
    {
        EmailContent emc = new stackConsole.EmailContent() { Subject = String.Format("{0} {1}", employ.Name, employ.Email), Body = "" }; 
        // proceed with emc 
    }
