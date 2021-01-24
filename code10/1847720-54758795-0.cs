    public class posts
    {    
        // add this constructor
        public posts()
        {
        }
        public dynamic jsonObj { get; set; }
    
        public posts(dynamic json)
        {
            jsonObj = json;
    
            if (jsonObj != null)
            {
    
                id = jsonObj.id;
                name = jsonObj.name;
                if(jsonObj.feed !=null)
                {
                    feed = new feed(jsonObj.feed);
    
                }
            }
        }
        public string id { get; set; }
        public string name { get; set; }
        public virtual feed feed { get; set; }
    
        public int postsId { get; set; }
    }
