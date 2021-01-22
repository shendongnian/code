    public class MyObject : IHasKey
    {
        public string LookupKey { get; set; }
    }
    
    public interface IHasKey
    {
        string LookupKey { get; set; }
    } 
    
    
    public static Dictionary<string, T> ConvertToDictionary<T>(IList<T> myList) where T: IHasKey 
    { 
        Dictionary<string, T> dict = new Dictionary<string, T>(); 
        foreach(T item in myList) 
        { 
            dict.Add(item.LookupKey, item); 
        } 
        return dict; 
    }
    
    List<MyObject> list = new List<MyObject>();
    MyObject o = new MyObject();
    o.LookupKey = "TADA";
    list.Add(o);
    Dictionary<string, MyObject> dict = ConvertToDictionary(list);
