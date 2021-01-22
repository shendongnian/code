    public abstract class Client : Entity
    {
        public virtual string Name { get; set; }
        public virtual string  Comments { get; set; }
        public virtual string  Requirement { get; set; }
        public virtual string  Complaints { get; set; }
     }
    public class GreatClient : Client
    {
        public virtual List<GreatOrder>  Orders { get; set; }
    }
    public class WebClient : Client
    {
        public virtual List<BadOrder> Orders { get; set; }
    }
    public static class ClientHelper
    {
        public static IEnumerable<Order> GetOrders(this Client client)
        {
            var result = new Dictionary<Type, Func<Client>>
                             {
                                 {typeof (GreatClient), () => { return ((GreatClient) client).Orders;}},
                                 {typeof (WebClient), ()=> { return ((WebClient) client).Orders;}}
                             };
            return result[dto.GetType()].Invoke();
        }
    }
    
    //Client code
    Client client = new WebClient();
    client.GetOrders();
