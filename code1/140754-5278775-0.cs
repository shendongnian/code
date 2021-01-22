    [DataContract]
    public class DeviceInfo
    {
        public Guid DeviceGuid
        {
            set
            {
                DeviceID = value.ToString();
            }
        }
        [DataMember]
        public string DeviceID { get; set; }
    }
