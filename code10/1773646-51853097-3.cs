    var cli = New System.Net.Mail.SmtpClient();
    cli.EnableSsl = true; //for some reason .config settings don't work here
    //no more cli settings
    var msg = System.Net.Mail.MailMessage();
    // do all other things
    //finally
    cli.Send(msg);
