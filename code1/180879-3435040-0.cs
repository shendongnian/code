    public sealed class Singleton
    {
        public static List<ISiteData> Details { get; private set; }
    
        private Singleton()
        {
            //create new instances of MasterSiteData and add to the list
        }
    
        private class MasterSiteData : ISiteData
        {
            public Guid GuidID {get;set;}
            public string Uri {get;set;}
            public int LinkNumber {get;set;}
    
            public MasterSiteData(Guid guid, string uri, int linkNumber)
            {
                GuidID = guid;
                Uri = uri;
                LinkNumber = linkNumber;
            }
        }
    }
    
    public interface ISiteData
    {
        Guid GuidID {get;set;}
        string Uri {get;set;}
        int LinkNumber {get;set;}
    }
