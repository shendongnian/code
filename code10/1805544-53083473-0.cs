     class RootClass
        {
            public int TotalCount { get; set; }
            [JsonProperty(PropertyName = "data")]
            public List<StudentInfo> stdinfo { get; set; }
        }
