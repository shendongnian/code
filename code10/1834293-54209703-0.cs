    public static string SendMail(string strsender, string strReceiver, string strsubject, string strbody)
        {
            try
            {
                MailMessage vMailMessage = new MailMessage();
                char[] separator = { ',' };
                vMailMessage.From = GetEmailAddress(strsender.Trim(), separator); //寄件人 //存取被拒
                vMailMessage.To.Add(GetEmailAddress(strReceiver.Trim(), separator)); //收件人                    
                //vMailMessage.Cc = GetEmailAddress(vDataRow["CC"].ToString().Trim(), separator);       //副本                    
                //vMailMessage.Bcc = GetEmailAddress(vDataRow["BCC"].ToString().Trim(), separator);     //密件副本  
                vMailMessage.Subject = strsubject.Trim(); //主旨
                vMailMessage.IsBodyHtml = true;
                vMailMessage.Body = strbody;
                SmtpMail.SmtpServer = "Webmail";  //設定Mail伺服器
                SmtpMail.Send(vMailMessage); //發送mail
                
                return "ok";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
