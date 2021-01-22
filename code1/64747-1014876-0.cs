    using System.Web.Mail;
    using System;
    public class MailSender
    {
        public static bool SendEmail(
            string pGmailEmail, 
            string pGmailPassword, 
            string pTo, 
            string pSubject,
            string pBody, 
            System.Web.Mail.MailFormat pFormat,
            string pAttachmentPath)
        {
        try
        {
            System.Web.Mail.MailMessage myMail = new System.Web.Mail.MailMessage();
            myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/smtpserver",
                              "smtp.gmail.com");
            myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/smtpserverport",
                              "465");
            myMail.Fields.Add
                ("http://schemas.microsoft.com/cdo/configuration/sendusing",
                              "2");
            //sendusing: cdoSendUsingPort, value 2, for sending the message using 
            //the network.
    
            //smtpauthenticate: Specifies the mechanism used when authenticating 
            //to an SMTP 
            //service over the network. Possible values are:
            //- cdoAnonymous, value 0. Do not authenticate.
            //- cdoBasic, value 1. Use basic clear-text authentication. 
            //When using this option you have to provide the user name and password 
            //through the sendusername and sendpassword fields.
            //- cdoNTLM, value 2. The current process security context is used to 
            // authenticate with the service.
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate","1");
            //Use 0 for anonymous
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/sendusername",
                pGmailEmail);
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/sendpassword",
                 pGmailPassword);
            myMail.Fields.Add
            ("http://schemas.microsoft.com/cdo/configuration/smtpusessl",
                 "true");
            myMail.From = pGmailEmail;
            myMail.To = pTo;
            myMail.Subject = pSubject;
            myMail.BodyFormat = pFormat;
            myMail.Body = pBody;
            if (pAttachmentPath.Trim() != "")
            {
                MailAttachment MyAttachment = 
                        new MailAttachment(pAttachmentPath);
                myMail.Attachments.Add(MyAttachment);
                myMail.Priority = System.Web.Mail.MailPriority.High;
            }
    
            System.Web.Mail.SmtpMail.SmtpServer = "smtp.gmail.com:465";
            System.Web.Mail.SmtpMail.Send(myMail);
            return true;
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    }
