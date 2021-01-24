    public class Class1 {
        public List<products> mItems;
        public Class1() {
            mItems = new List<products>();
            foreach (var property in Array)
            {
                //Convert every value in Array to string
                var propertyList = JsonConvert.DeserializeObject<List<products>>(property.ToString());
                //Add all strings to List
                mItems.AddRange(propertyList);
            }
        }
    }
    public class Class2 {
        public List<products> mItems;
        public Class2() {
            var class1Instance = new Class1();
            mItems = class1Instance. mItems;
        }
    }
