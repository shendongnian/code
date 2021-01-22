    [Serializable]
    public abstract class SocialNetworkBase : ISocialNetwork
    {
        public abstract string UserName { get; set; }
    }
    
    [Serializable]
    public class Twitter : SocialNetworkBase
    {
        public override string UserName { get; set; }
    }
    
    [Serializable]
    public class LinkedIn : SocialNetworkBase
    {
        public override string UserName { get; set; }
    }
