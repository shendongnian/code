    class User
    {
        [JsonProperty(PropertyName = "userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }
        [JsonProperty(PropertyName = "userId", NullValueHandling = NullValueHandling.Ignore)]
        public int  UserId { get; set; }
        [JsonProperty(PropertyName = "accompletedSetup", NullValueHandling = NullValueHandling.Ignore)]
        public string AccompletedSetup { get; set; }
        [JsonProperty(PropertyName = "accompletedInfo", NullValueHandling = NullValueHandling.Ignore)]
        public AccompletedInfo AccompletedInfo { get; set; }
    }
