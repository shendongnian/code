    public class MyMap {
        public String FirstField { get; set; }
        public String SecondField { get; set; }
    }
    public class MyMapCollection : BindingList<MyMap>
    {
        public MyMapCollection Clone()
        {
            MyMapCollection result = new MyMapCollection();
    
            foreach (MyMap map in this)
                result.Add(new MyMap() {
                    FirstField = map.FirstField, SecondField = map.SecondField });
    
            return result;
        }
    }
