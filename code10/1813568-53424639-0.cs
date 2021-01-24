    Microsoft.Office.Interop.Outlook.Application app;
                    try
                    {
                        app = (Microsoft.Office.Interop.Outlook.Application)Marshal.GetActiveObject("Outlook.Application");
                    }
                    catch
                    {
                        app = new Microsoft.Office.Interop.Outlook.Application();
                    }
    
                    if (app == null)
                    {
                        return;
                    }
                    string stringHtmlBodyfromFile = File.ReadAllText(@"codeFileUrl");
                    Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem) as
                                                                         Microsoft.Office.Interop.Outlook.MailItem;
                    mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                    mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                    mailItem.Subject = “subject”;
                   mailItem.Recipients.Add("");
                    mailItem.HTMLBody = stringHtmlBodyfromFile;
                    mailItem.CC = cc;
    
                    mailItem.Attachments.Add(@"AttachmentUrl");
                    mailItem.Save();
                            }
                catch (Exception eX)
                {
                   // XtraMessageBox.Show(eX.Message + "\n" + eX.StackTrace + "\n" + eX.Source + "\n" + eX.InnerException);
                }
