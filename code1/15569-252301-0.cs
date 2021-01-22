    [DataContract]
    public class TestClass
    {
        private static readonly DateTime unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
        [IgnoreDataMember]
        public DateTime MyDateTime { get; set; }
        [DataMember(Name = "MyDateTime")]
        private int MyDateTimeTicks
        {
            get { return (int)(this.MyDateTime - unixEpoch).TotalSeconds; }
            set { this.MyDateTime = unixEpoch.AddSeconds(Convert.ToInt32(value)); }
        }
    }
