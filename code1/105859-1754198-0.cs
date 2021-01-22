    public interface IObjectMapper<U> where U:new
    {
        T MapObject<T>(U arg) where T:new()
        U DemapObject<T>(T arg);
    }
    public class CustomObjectMapper : IObjectMapper<NameValueCollection>
    {
        T MapObject<T>(NameValueCollection arg) where T:new(){
           ....
        }
 
        NameValueCollection DemapObject<T>(T arg)
        {
              ....
        }
    }
    IObjectMapper<NameValueCollection> mapper = new CustomObjectMapper();
