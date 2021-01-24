        static void Main()
        {
            var propertyList = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("PropertyName1","Value1"),
                new KeyValuePair<string, string>("PropertyName2","Value2"),
                new KeyValuePair<string, string>("PropertyName3","Value3"),
                new KeyValuePair<string, string>("PropertyName4","Value4"),
                new KeyValuePair<string, string>("PropertyName5","Value5"),
            };
            var requestData = new RequestData();
            //reflection allows you to loop through the properties of a class
            foreach (var property in requestData.GetType().GetProperties())
            {
                //you can loop through your list (here I made an assumption that it's a list of KeyValuePair)
                foreach (var keyValuePair in propertyList)
                {
                    //if the key matches the property name, assign the value
                    if (property.Name.Equals(keyValuePair.Key))
                    {
                        property.SetValue(requestData, keyValuePair.Value);
                    }
                }
            }
            //to show that they are properly set
            Console.WriteLine(requestData.PropertyName1);
            Console.WriteLine(requestData.PropertyName2);
            Console.WriteLine(requestData.PropertyName3);
            Console.WriteLine(requestData.PropertyName4);
        }
    }
    public class RequestData
    {
        public string PropertyName1 { get; set; }
        public string PropertyName2 { get; set; }
        public string PropertyName3 { get; set; }
        public string PropertyName4 { get; set; }
    }
