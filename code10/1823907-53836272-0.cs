     public static bool EmailReport(
                   String Subject,
                   String Body,
                   String FromAddress,
                   String FromName
                   String[] To,
                   String[] CC,
                   out String sError)
            {
                MailMessage m = new MailMessage();
                SmtpClient smtp = new SmtpClient("<insert your email server name here i.e.: mail.Mycompany.com>");
                smtp.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                m.Subject = Subject;
                m.Body = Body;
                m.From = new MailAddress(FromAddress, FromName);
                foreach (String sTo in To)
                {
                    m.To.Add(sTo);
                }
                if (CC != null)
                {
                    foreach (String sCC in CC)
                    {
                        m.CC.Add(sCC);
                    }
                }
                try
                {
                    smtp.Send(m);
                    sError = "";
                    return true;
                }
                catch (Exception ex)
                {
                    sError = ex.Message + "\r\n\r\n" + ex.StackTrace;
                    return false;
                }
            }
