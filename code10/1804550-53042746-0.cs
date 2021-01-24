      public class Delivery
            {
                public int status { get; set; }
                public string resp_msg { get; set; }
                public string mail_from { get; set; }
                public int time_started { get; set; }
                public int time_finished { get; set; }
                public string resp_code_description { get; set; }
                public int sender_id { get; set; }
                public string campaign_id { get; set; }
                public string rcpt_to { get; set; }
                public int tries { get; set; }
                public int resp_code { get; set; }
                public string tracking_id { get; set; }
                public int resp_class { get; set; }
                public string subject { get; set; }
            }
    
            public class DataRootObject
            {
                public List<Delivery> delivery { get; set; }
                public double last_update_time { get; set; }
            }
