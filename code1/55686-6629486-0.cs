    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Outlook = Microsoft.Office.Interop.Outlook;
    using Microsoft.Office;
    using System.Xml.Linq;
    
    namespace ProcessEmail
    {
        class Program
        {
            static void Main(string[] args)
            {
                Outlook.Application outlook = new Outlook.Application();
                Outlook.NameSpace ns = outlook.GetNamespace("Mapi");
                object _missing = Type.Missing;
                ns.Logon(_missing, _missing, false, true);
    
                Outlook.MAPIFolder inbox = ns.GetDefaultFolder(Microsoft.Office.Interop.Outlook.OlDefaultFolders.olFolderInbox);
    
                int unread = inbox.UnReadItemCount;
                XElement xmlMail = new XElement("Mail");
                foreach (Outlook.MailItem mail in inbox.Items)
                {               
                    string s = mail.Subject;
                   
                    if (s != null)
                    {
                        if (s.Contains("Tickets") || (s.Contains("Support")))
                        {
                            string[] splitter = s.Split('#');
                            string[] split = splitter[1].Split(']');                       
                            string num = split[0].Trim();
    
                            XElement mailrow = new XElement("MailRow",
                                new XElement("Ticket_Number",num),
                                new XElement("Subject", mail.Subject),
                                new XElement("Body",  new XCData(mail.Body)),
                                new XElement("From", mail.SenderEmailAddress)
                                );
                            xmlMail.Add(mailrow);
                        }
                    }
                    
                }
                xmlMail.Save("E:\\mailxml.xml");
                
                
            }
        }
    }
