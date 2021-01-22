    using System;
    using System.Net.Mail;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Attachment attachment = Attachment.CreateAttachmentFromString("", "=?iso-8859-1?Q?=A1Hola,_se=F1or!?=");
                Console.WriteLine(attachment.Name);
            }
        }
    }
