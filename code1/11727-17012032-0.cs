      Redemption.RDOSession Session = new RDOSession();
      Redemption.RDOMail Msg = Session.CreateMessageFromMsgFile(@"c:\temp\YourMsgFile.msg");
      Msg.Sent = true;
      Msg.Subjkect = "test";
      Msg.Body = "test body";
      Msg.Recipients.AddEx("the user", "user@domain.demo", "SMTP", rdoMailRecipientType.olTo);
      Msg.Save();
