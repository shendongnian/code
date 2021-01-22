    public class Order
    {
     public string name { get; set; }
     public int orderid { get; set; }
     public int price { get; set; }
    }
    [WebMethod]
    public static void SetOrder(object order)
    {
        Order ord = GetOrder(order);
        Console.WriteLine(ord.name +","+ord.price+","+ord.orderid);        
    }
    public static Order GetOrder(object order)
    {
        Order ord = new Order();
        Dictionary<string,object> tmp = (Dictionary<string,object>) order;
        object name = null;
        object price = null;
        object orderid = null;
        tmp.TryGetValue("name", out name);
        tmp.TryGetValue("price", out price);
        tmp.TryGetValue("orderid", out orderid);
        ord.name = name.ToString();
        ord.price = (int)price;
        ord.orderid = (int) orderid;
        return ord;
    }
