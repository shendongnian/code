    using System;
    namespace console
    {
        public interface ISmptSectionPathProvider
        {
            string SmtpSectionPath
            {
                get;
            }
        }
        
        public class AppConfig : ISmptSectionPathProvider
        {
            public string SmtpSectionPath
            {
                get { return Constants.SmtpSectionPath; }
            }
        }
        public class EmailConfig : ISmptSectionPathProvider
        {
            public string SmtpSectionPath
            {
                get { return Constants.SmtpSectionPath; }
            }
        }
        public class Constants
        {
            public static string SmtpSectionPath = "MailSettings";
        }
        
        class CommandLineApplication
        {
            public static void Main(string[] args)
            {
                ISmptSectionPathProvider provider = new AppConfig();
                System.Console.WriteLine(provider.SmtpSectionPath);
                provider = new EmailConfig();
                System.Console.WriteLine(provider.SmtpSectionPath);
            }
        }
    }
