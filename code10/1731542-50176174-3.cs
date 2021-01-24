    public class MailGunResponse
    {
            public string address { get; set; }
            public string did_you_mean { get; set; }
            public bool is_disposable_address { get; set; }
            public bool is_role_address { get; set; }
            public bool is_valid { get; set; }
            public bool mailbox_verification { get; set; } //Make sure it is bool!
            public Parts parts { get; set; }
    }
    public class Parts
    {
            public string display_name { get; set; }
            public string domain { get; set; }
            public string local_part { get; set; }
     }
