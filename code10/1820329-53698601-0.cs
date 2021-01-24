    using Microsoft.Office.Interop.Outlook;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp7
    {
        class Program
        {
           static void Main(string[] args)
            {
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
                    string stringHtmlBodyfromFile = File.ReadAllText(@"D:\test.html");
                    Microsoft.Office.Interop.Outlook.MailItem mailItem = app.CreateItem(Microsoft.Office.Interop.Outlook.OlItemType.olMailItem) as
                                                                         Microsoft.Office.Interop.Outlook.MailItem;
                    mailItem.BodyFormat = Microsoft.Office.Interop.Outlook.OlBodyFormat.olFormatHTML;
                    mailItem.Importance = Microsoft.Office.Interop.Outlook.OlImportance.olImportanceHigh;
                    mailItem.Subject = subject;
                    mailItem.To = “sendemail address”;
                    mailItem.Recipients.Add();
                    mailItem.HTMLBody = stringHtmlBodyfromFile;
                    mailItem.CC = “ccmailAddress”;
    
                    mailItem.Attachments.Add();
    
                   ((Microsoft.Office.Interop.Outlook._MailItem)mailItem).Send();
    
            }
       }
    }
