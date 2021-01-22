    string smtpAddress = "smtp.email.com";
    try
    {
      CDO.Message oMessage = new CDO.Message();
      // set message
      ADODB.Stream oStream = new ADODB.Stream();
      oStream.Charset = "ascii";
      oStream.Open();
      oStream.WriteText(MHTmessage);
      oMessage.DataSource.OpenObject(oStream, "_Stream");
      // set configuration
      ADODB.Fields oFields = oMessage.Configuration.Fields;
      oFields("http://schemas.microsoft.com/cdo/configuration/sendusing").Value = CDO.CdoSendUsing.cdoSendUsingPort;
      oFields("http://schemas.microsoft.com/cdo/configuration/smtpserver").Value = smtpAddress;
      oFields.Update();
      // set other values
      oMessage.MimeFormatted = true;
      oMessage.Subject = subject;
      oMessage.Sender = emailFrom;
      oMessage.To = emailTo;
      oMessage.Send();
    }
    catch (Exception ex)
    {
      // something wrong
    }
}
