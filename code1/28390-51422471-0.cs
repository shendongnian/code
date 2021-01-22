    namespace SmtpSendingEmialMessage
    { 
        public class EmailSetupData
        {
            public string EmailFrom { get; set; }
            public string EmailUserName { get; set; }
            public string EmailPassword { get; set; }
            public string EmailSmtpServerName { get; set; }
            public int EmailSmtpPortNumber { get; set; }
            public Boolean SSLActive { get; set; } = false;
        }
        public class SendingResultData
        {
            public string SendingEmailAddress { get; set; }
            public string SendingEmailSubject { get; set; }
            public DateTime SendingDateTime { get; set; }
            public Boolean SendingEmailSuccess { get; set; }
            public string SendingEmailMessage { get; set; }
        }
        public class OneRecData
        {
            public string RecEmailAddress { get; set; } = "";
            public string RecEmailSubject { get; set; } = "";
        }
        public class SendingProcess
        {
            public string EmailCommonSubjectOptional { get; set; } = "";
            private EmailSetupData EmailSetupParam { get; set; }
            private List<OneRecData> RecDataList { get; set; }
            private string EmailBodyContent { get; set; }
            private Boolean IsEmailBodyHtml { get; set; }
            private string EmailAttachFilePath { get; set; }
            public SendingProcess(List<OneRecData> MyRecDataList, String MyEmailTextContent, String MyEmailAttachFilePath, EmailSetupData MyEmailSetupParam, Boolean EmailBodyHtml)
            {
                RecDataList = MyRecDataList;
                EmailBodyContent = MyEmailTextContent;
                EmailAttachFilePath = MyEmailAttachFilePath;
                EmailSetupParam = MyEmailSetupParam;
                IsEmailBodyHtml = EmailBodyHtml;
            }
            public List<SendingResultData> SendAll()
            {
                List<SendingResultData> MyResList = new List<SendingResultData>();
                foreach (var js in RecDataList)
                {
                    using (System.Net.Mail.MailMessage MyMes = new System.Net.Mail.MailMessage())
                    {
                        DateTime SadaJe = DateTime.Now;
                        Boolean IsOK = true;
                        String MySendingResultMessage = "Sending OK";
                        String MessageSubject = EmailCommonSubjectOptional;
                        if (MessageSubject == "")
                        {
                            MessageSubject = js.RecEmailSubject;
                        }
                        try
                        {
                            System.Net.Mail.MailAddress MySenderAdd = new System.Net.Mail.MailAddress(js.RecEmailAddress);
                            MyMes.To.Add(MySenderAdd);
                            MyMes.Subject = MessageSubject;
                            MyMes.Body = EmailBodyContent;
                            MyMes.Sender = new System.Net.Mail.MailAddress(EmailSetupParam.EmailFrom);
                            MyMes.ReplyToList.Add(MySenderAdd);
                            MyMes.IsBodyHtml = IsEmailBodyHtml;
                        }
                        catch(Exception ex)
                        {
                            IsOK = false;
                            MySendingResultMessage ="Sender or receiver Email address error." +  ex.Message;
                        }
                        if (IsOK == true)
                        {
                            try
                            {
                                if (EmailAttachFilePath != null)
                                {
                                    if (EmailAttachFilePath.Length > 5)
                                    {
                                        MyMes.Attachments.Add(new System.Net.Mail.Attachment(EmailAttachFilePath));
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                IsOK = false;
                                MySendingResultMessage ="Emial attach error. " +  ex.Message;
                            }
                            if (IsOK == true)
                            {
                                using (System.Net.Mail.SmtpClient MyCl = new System.Net.Mail.SmtpClient())
                                {
                                    MyCl.EnableSsl = EmailSetupParam.SSLActive;
                                    MyCl.Host = EmailSetupParam.EmailSmtpServerName;
                                    MyCl.Port = EmailSetupParam.EmailSmtpPortNumber;
                                    try
                                    {
                                        MyCl.Credentials = new System.Net.NetworkCredential(EmailSetupParam.EmailUserName, EmailSetupParam.EmailPassword);
                                    }
                                    catch (Exception ex)
                                    {
                                        IsOK = false;
                                        MySendingResultMessage = "Emial credential error. " + ex.Message;
                                    }
                                    if (IsOK == true)
                                    {
                                        try
                                        {
                                            MyCl.Send(MyMes);
                                        }
                                        catch (Exception ex)
                                        {
                                            IsOK = false;
                                            MySendingResultMessage = "Emial sending error. " + ex.Message;
                                        }
                                    }
                                }
                            }
                        }
                        MyResList.Add(new SendingResultData
                        {
                                SendingDateTime = SadaJe,
                                SendingEmailAddress = js.RecEmailAddress,
                                SendingEmailMessage = MySendingResultMessage,
                                SendingEmailSubject = js.RecEmailSubject,
                                SendingEmailSuccess = IsOK
                        });
                    }
                
                }
                return MyResList;
            }
        }
    }
