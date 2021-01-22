       class Program
        {
            static void Main(string[] args)
            {
                var mo = new MyObject { integerValue = null, dateTimeValue = null };
                var ser = Newtonsoft.Json.JsonConvert.SerializeObject(mo);
                var deser = Newtonsoft.Json.JsonConvert.DeserializeObject(ser, typeof(MyObject));
            }
        }
    
        public class MyObject
        {
            public int? integerValue { get; set; }
            public DateTime? dateTimeValue { get; set; }        
        }  
