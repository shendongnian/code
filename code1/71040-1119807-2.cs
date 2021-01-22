    public class MyClass
    {
        private List<MyItem> _Items = new List<MyItem> ();
        public MyClass AddItem (MyItem item)
        {
            // Add the object
            if (item != null)
                _Items.Add (item)
    
            return this;
        }
    }
