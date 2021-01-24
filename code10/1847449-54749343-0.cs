    internal class Program
    {
        private static void Main(string[] args)
        {
            var myEntity = new MyEntity();
            var someDateTime = DateTime.Now;
            myEntity.DynamicDataValue = someDateTime;
            var someDateTime2 = (DateTime) myEntity.DynamicDataValue;
            Console.WriteLine(someDateTime2.AddHours(1));
        }
        public class MyEntity
        {
            public string DynamicData { get; set; }
            public string DynamicDataType { get; set; }
            [NotMapped]
            public object DynamicDataValue
            {
                get => JsonConvert.DeserializeObject(DynamicData, Type.GetType(DynamicDataType));
                set
                {
                    DynamicData = JsonConvert.SerializeObject(value);
                    DynamicDataType = value.GetType().FullName;
                }
            }
        }
    }
