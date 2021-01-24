    public class UsersClient : BaseClient
    {
        public UsersClient (ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger)
            : base(cache, serializer, errorLogger, "http://yourBaseUrl.com") { }
    
        public static User GetByID(int id)
        {
            RestRequest request = new RestRequest("users/{id}", Method.GET);
            request.AddUrlSegment("id", id.ToString());
            return GetFromCache<User>(request, "User" + id.ToString());
        }
    
    }
