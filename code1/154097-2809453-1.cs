    public class MyObjectDataRowConverter : IDataRowConverter<MyObject>
    {
        public MyObject Convert(DataRow row)
        {
            MyObject myObject = new MyObject();
    
            // Initialize object using the row instance
    
            return myObject;
        }
    }
