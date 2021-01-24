    using Microsoft.Office.Interop.Outlook;
    using outlookApp = Microsoft.Office.Interop.Outlook;
    
    namespace z_Console_Scratch
    {
        class Program
        {
            static void Main(string[] args)
            {
                Microsoft.Office.Interop.Outlook.Application outlookApp = new Microsoft.Office.Interop.Outlook.Application();
    
                Microsoft.Office.Interop.Outlook.MailItem mailItem = (Microsoft.Office.Interop.Outlook.MailItem)outlookApp.CreateItem(OlItemType.olMailItem);
    
                mailItem.Subject = "test subject";
                mailItem.HTMLBody = "<html><body>This is the <strong>funky</strong> message body</body></html>";
                mailItem.Display(false);
    
            }
    
    
        }
      
    }
