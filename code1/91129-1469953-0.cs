    public class MySessionThing
    {
        public object this[string key]
        {
            //called when we ask for something = mySession["value"]
            get
            {
                return MyGetData(key);
            }
            //called when we assign mySession["value"] = something
            set
            {
                MySetData(key, value);
            }
        }
    
        private object MyGetData(string key)
        {
            //lookup and return object
        }
    
        private void MySetData(string key, object value)
        {
            //store the key/object pair to your repository
        }
    }
