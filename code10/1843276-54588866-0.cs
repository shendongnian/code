     public class CustomUserIdProvider: IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            //get current user id by httpcontext
        }
    }
