    public class FacebookResolver : SimpleTypeResolver
    {
        public FacebookResolver() { }
        public override Type ResolveType(string id)
        {
            if(id == "video") return typeof(Video);
            else if (id == "status") return typeof(Status)
            else return base.ResolveType(id);
        }
    }
