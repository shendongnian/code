    public class MyClass
    {
        public DateTime Date { get; set; }
        public string User { get; set; }
        public int UserId { get; set; }
        public MyClass(IDictionary<string, object> data)
        {
            Date = DateTime.Parse(data["Date"].ToString());
            User = data["User"].ToString();
            UserId = int.Parse(data["UserId"].ToString());
        }
    }
