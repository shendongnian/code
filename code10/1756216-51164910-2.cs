    using System;
    using System.Collections.Generic;
    using System.Globalization;
    
    namespace YourApp
    {
        [DataContract]
        public class Ev
        {
            [DataMember(Name = "events")]
            public IList<Event> Events { get; set; }
        }
        [DataContract]
        public class Event
        {
            [DataMember(Name ="id")]
            public string Id { get; set; }
    
            [DataMember(Name ="timestamp")]
            public DateTimeOffset Timestamp { get; set; }
    
            [DataMember(Name ="action")]
            public string Action { get; set; }
    
            [DataMember(Name ="target")]
            public Target Target { get; set; }
    
            [DataMember(Name ="request")]
            public Request Request { get; set; }
    
            [DataMember(Name ="actor")]
            public object Actor { get; set; }
    
            [DataMember(Name ="source")]
            public Source Source { get; set; }
        }
    
        [DataContract]
        public class Request
        {
            [DataMember(Name ="id")]
            public string Id { get; set; }
    
            [DataMember(Name = "addr")]
            public string Addr { get; set; }
    
            [DataMember(Name = "host")]
            public string Host { get; set; }
    
            [DataMember(Name = "method")]
            public string Method { get; set; }
    
            [DataMember(Name = "useragent")]
            public string Useragent { get; set; }
        }
    
        [DataContract]
        public class Source
        {
            [DataMember(Name = "addr")]
            public string Addr { get; set; }
    
            [DataMember(Name = "instanceID")]
            public string InstanceId { get; set; }
        }
    
        [DataContract]
        public class Target
        {
            [DataMember(Name = "mediaType")]
            public string MediaType { get; set; }
    
            [DataMember(Name = "size")]
            public long Size { get; set; }
    
            [DataMember(Name = "digest")]
            public string Digest { get; set; }
    
            [DataMember(Name = "length")]
            public long Length { get; set; }
    
            [DataMember(Name = "repository")]
            public string Repository { get; set; }
    
            [DataMember(Name = "url")]
            public string Url { get; set; }
    
            [DataMember(Name = "tag")]
            public string Tag { get; set; }
        }
    }
