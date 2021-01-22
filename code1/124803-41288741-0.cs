    static void Main(string[] args)
    {
        var mo = new MyObject ();
        var ser = Newtonsoft.Json.JsonConvert.SerializeObject(mo);
        var myStr = "{}";
        var myStr1 = "{tITi: 10}";
        var myStr2 = "{integerValue: 10}";
        var deser0 = Newtonsoft.Json.JsonConvert.DeserializeObject(ser, typeof(MyObject));
        var deser1 = Newtonsoft.Json.JsonConvert.DeserializeObject(myStr, typeof(MyObject));
        var deser2 = Newtonsoft.Json.JsonConvert.DeserializeObject(myStr1, typeof(MyObject));
        var deser3 = Newtonsoft.Json.JsonConvert.DeserializeObject(myStr2, typeof(MyObject));
    }
    public class MyObject
    {
        public int? integerValue { get; set; }
        public DateTime? dateTimeValue { get; set; }
        public int toto { get; set;  } = 5;
        public int Titi;
    }
