    using (SmtpClient smtp = new SmtpClient())
                    {
                        NetworkCredential credential = new NetworkCredential
                        {
                            UserName = WebConfigurationManager.AppSettings["UserName"],
                            Password = WebConfigurationManager.AppSettings["Password"],
                        };
                        smtp.Credentials = credential;
                        smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                        smtp.DeliveryFormat = SmtpDeliveryFormat.SevenBit;
                        smtp.Host = WebConfigurationManager.AppSettings["Host"];
                        smtp.Port = WebConfigurationManager.AppSettings["Port"].ToNcInt();
                        smtp.EnableSsl = Convert.ToBoolean(WebConfigurationManager.AppSettings["EnableSsl"]);
                        smtp.Send(mail);
                    }
