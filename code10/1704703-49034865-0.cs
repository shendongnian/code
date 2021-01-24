    // To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
    //
    //    using QuickType;
    //
    //    var pwdResetRequest = PwdResetRequest.FromJson(jsonString);
    
    namespace QuickType
    {
        using System;
        using System.Collections.Generic;
        using System.Net;
    
        using System.Globalization;
        using Newtonsoft.Json;
        using Newtonsoft.Json.Converters;
        using J = Newtonsoft.Json.JsonPropertyAttribute;
    
        public partial class PwdResetRequest
        {
            [J("query")]            public string Query { get; set; }          
            [J("topScoringIntent")] public Ntent TopScoringIntent { get; set; }
            [J("intents")]          public Ntent[] Intents { get; set; }       
            [J("entities")]         public Entity[] Entities { get; set; }     
        }
    
        public partial class Entity
        {
            [J("entity")]     public string EntityEntity { get; set; }
            [J("type")]       public string Type { get; set; }        
            [J("startIndex")] public long StartIndex { get; set; }    
            [J("endIndex")]   public long EndIndex { get; set; }      
        }
    
        public partial class Ntent
        {
            [J("intent")] public string Intent { get; set; }
            [J("score")]  public double Score { get; set; } 
        }
    
        public partial class PwdResetRequest
        {
            public static PwdResetRequest FromJson(string json) => JsonConvert.DeserializeObject<PwdResetRequest>(json, QuickType.Converter.Settings);
        }
    
        public static class Serialize
        {
            public static string ToJson(this PwdResetRequest self) => JsonConvert.SerializeObject(self, QuickType.Converter.Settings);
        }
    
        internal class Converter
        {
            public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
            {
                MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
                DateParseHandling = DateParseHandling.None,
                Converters = { 
                    new IsoDateTimeConverter()
                    {
                        DateTimeStyles = DateTimeStyles.AssumeUniversal,
                    },
                },
            };
        }
    }
