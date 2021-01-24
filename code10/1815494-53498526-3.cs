        public class Rootobject
        {
            public Application[] Application { get; set; }
            public Mailsettings MailSettings { get; set; }
        }
        public class Mailsettings
        {
            public string MailTo { get; set; }
            public string MailSubject { get; set; }
        }
        public class Application
        {
            public string Office { get; set; }
            public string[] LogPath { get; set; }
        }
