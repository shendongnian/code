        [DataContract]
        public class Country
        {
            [DataMember]  
            public string name { get; set; }
            [DataMember]  
            public string capital { get; set; }
            [DataMember]  
            public string region { get; set; }
            [DataMember]  
            public string subRegion { get; set; }
            [DataMember]  
            public int population { get; set; }
            [DataMember]  
            public Currency[] currencies { get; set; }
            [DataMember]  
            public Language[] languages { get; set; }
            public override string ToString()
            {
                return "The country name is " + name + "\n" + "The country capital is " + capital + "\n" + "The country region is " + region
                       + "\n" + "The country sub region is " + subRegion + "\n" + "The country population is " + population + "\n"
                       + "The country currency is " + currencies + "\n" + "The country language is " + languages;
            }
        }
        [DataContract]  
        public class Currency
        {
            [DataMember]  
            public string code { get; set; }
            [DataMember]  
            public string name { get; set; }
            [DataMember]  
            public string symbol { get; set; }
        }
        [DataContract]
        public class Language
        {
            [DataMember]  
            public string iso639_1 { get; set; }
            [DataMember]  
            public string iso639_2 { get; set; }
            [DataMember]  
            public string name { get; set; }
            [DataMember] 
            public string nativeName { get; set; }
        }
