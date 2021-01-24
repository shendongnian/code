    [DataContract]
        public class TwitterJson
        {
            [DataMember(Name = "has_more_items")]
            bool hasMore { get; set; } // has_more_items
    
            [DataMember(Name = "items_html")]
            string rawText { get; set; } // items_html
    
            [DataMember(Name = "min_position")]
            string nextKey { get; set; } // min_position
        }
