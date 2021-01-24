    public interface IConfigurationSettings {
        string AppSettings[string key] { get; }
    }
    public interface ISmtpClient: IDisposable {
        void Send(Message message);
    }
    public interface IEmailLogging  {
        void SendEmail(string error);
    }
    public class EmailLogging: IEmailLogging {
        private readonly IConfigurationSettings ConfigurationSettings;
        private readonly ISmtpClient client;
        public EmailLogging (IConfigurationSettings settings,  ISmtpClient client) {
            this.ConfigurationSettings = settings;
            this.client = client;
        }
        public void SendEmail(string error) {
           string EmailFrom = ConfigurationSettings.AppSettings["EmailFrom"];
           string EmailTo = ConfigurationSettings.AppSettings["EmailTo"];
           string errorLogLocation = ConfigurationSettings.AppSettings["ErrorLogLocation"];
           //...
           
           client.Send(mailMessage);            
        }
    }
