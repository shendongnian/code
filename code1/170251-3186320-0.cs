    using System;
    using Independentsoft.Pst;
    
    namespace Sample
    {
        class Program
        {
            static void Main(string[] args)
            {
                PstFile file = new PstFile("c:\\testfolder\\Outlook.pst");
    
                using (file)
                {
                    Folder inbox = file.MailboxRoot.GetFolder("Inbox");
    
                    if (inbox != null)
                    {
                        ItemCollection items = inbox.GetItems();
    
                        for (int m = 0; m < items.Count; m++)
                        {
                            if (items[m] is Message)
                            {
                                Message message = (Message)items[m];
    
                                Console.WriteLine("Id: " + message.Id);
                                Console.WriteLine("Subject: " + message.Subject);
                                Console.WriteLine("DisplayTo: " + message.DisplayTo);
                                Console.WriteLine("DisplayCc: " + message.DisplayCc);
                                Console.WriteLine("SenderName: " + message.SenderName);
                                Console.WriteLine("SenderEmailAddress: " + message.SenderEmailAddress);
                                Console.WriteLine("----------------------------------------------------------------");
                            }
                        }
                    }
                }
    
                Console.WriteLine("Press ENTER to exit.");
                Console.Read();
            }
        }
    }
