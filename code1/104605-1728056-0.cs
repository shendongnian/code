    public class MyObj
    {
        public string name;
    }
    class Program
    {
        static void Main(string[] args)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var json = "{\"name\" : null}";
            var myObj = ser.Deserialize<MyObj>(json);
            Console.WriteLine(myObj.name);
        }
    }
