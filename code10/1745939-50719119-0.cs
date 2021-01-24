        public partial class RootObject
        {
            [JsonProperty("not_modified_since")]
            public DateTimeOffset NotModifiedSince { get; set; }
    
            [JsonProperty("host")]
            public List<Host> Host { get; set; }
        }
    
        public partial class Host
        {
            [JsonProperty("active")]
            public bool Active { get; set; }
    
            [JsonProperty("config_profile_bag_id")]
            public long ConfigProfileBagId { get; set; }
    
            [JsonProperty("container_id")]
            public long ContainerId { get; set; }
    
            [JsonProperty("db_pickup_tm_utc")]
            public DateTimeOffset DbPickupTmUtc { get; set; }
    
            [JsonProperty("discovery_status")]
            public long DiscoveryStatus { get; set; }
    
            [JsonProperty("display_unit_id")]
            public long DisplayUnitId { get; set; }
    
            [JsonProperty("domain_id")]
            public long DomainId { get; set; }
    
            [JsonProperty("geolocation")]
            public string Geolocation { get; set; }
    
            [JsonProperty("id")]
            public long Id { get; set; }
    
            [JsonProperty("license_end_date")]
            public object LicenseEndDate { get; set; }
    
            [JsonProperty("licensed")]
            public bool Licensed { get; set; }
    
            [JsonProperty("name")]
            public string Name { get; set; }
    
            [JsonProperty("nscreens")]
            public long Nscreens { get; set; }
    
            [JsonProperty("primary_mac_address")]
            public string PrimaryMacAddress { get; set; }
    
            [JsonProperty("public_key_fingerprint")]
            public string PublicKeyFingerprint { get; set; }
    
            [JsonProperty("remote_clear_db_tm_utc")]
            public DateTimeOffset RemoteClearDbTmUtc { get; set; }
    
            [JsonProperty("remote_reboot_tm_utc")]
            public DateTimeOffset RemoteRebootTmUtc { get; set; }
    
            [JsonProperty("secondary_mac_address")]
            public string SecondaryMacAddress { get; set; }
    
            [JsonProperty("volume")]
            public long Volume { get; set; }
        }
    }
