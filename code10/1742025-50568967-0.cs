    public class Response
    {
    }
    public abstract class GetResponseBase
    {
        public abstract Response GetResponse();
    }
    public class GetResponsePrimary : GetResponseBase
    {
        public override Response GetResponse()
        {
            return new Response();
        }
    }
    public class GetResponseSecondary : GetResponseBase
    {
        public override Response GetResponse()
        {
            return new Response();
        }
    }
