    public class DynClass<T, P>
        {
            public DynClass()
            {
                _fields = new Dictionary<T, P>();
            }
    
            private IDictionary<T, P> _fields;
    
            public IDictionary<T, P> Fields
            {
                get { return _fields; }
            }
    
        }
    
        public class TestGenericInstances
        {
            public TestGenericInstances()
            {
                Client cli = new Client("Ash", "99999999901");
    
                /* Here you can create any instances of the Class. 
                 * Also DynClass<string, object>
                 * */
                DynClass<string, Client> gen = new DynClass<string, Client>();
                /* Add the fields
                 * */
                gen.Fields.Add("clientName", cli);
    
                /* Add the objects to the List
                 * */
                List<object> lstDyn = new List<object>().Add(gen);
            }        
        }
