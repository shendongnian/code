     using System;
        using System.Collections.Generic;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
    
        public partial class JsonModel
        {
            [JsonProperty("response")]
            public Response Response { get; set; }
        }
    
        public partial class Response
        {
            [JsonProperty("players")]
            public List<Player> Players { get; set; }
        }
    
        public partial class Player
        {
            [JsonProperty("steamid")]
            public string Steamid { get; set; }
    
            [JsonProperty("communityvisibilitystate")]
            public long Communityvisibilitystate { get; set; }
    
            [JsonProperty("profilestate")]
            public long Profilestate { get; set; }
    
            [JsonProperty("personaname")]
            public string Personaname { get; set; }
    
            [JsonProperty("lastlogoff")]
            public long Lastlogoff { get; set; }
    
            [JsonProperty("commentpermission")]
            public long Commentpermission { get; set; }
    
            [JsonProperty("profileurl")]
            public string Profileurl { get; set; }
    
            [JsonProperty("avatar")]
            public string Avatar { get; set; }
    
            [JsonProperty("avatarmedium")]
            public string Avatarmedium { get; set; }
    
            [JsonProperty("avatarfull")]
            public string Avatarfull { get; set; }
    
            [JsonProperty("personastate")]
            public long Personastate { get; set; }
    
            [JsonProperty("realname")]
            public string Realname { get; set; }
    
            [JsonProperty("primaryclanid")]
            public string Primaryclanid { get; set; }
    
            [JsonProperty("timecreated")]
            public long Timecreated { get; set; }
    
            [JsonProperty("personastateflags")]
            public long Personastateflags { get; set; }
        }
