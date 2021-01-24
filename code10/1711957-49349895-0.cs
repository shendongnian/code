    public class MonitoredCustomerObject
    {
        // Assumption that the Get/Set delegates are stored in a simple Tuple.
        private Dictionary<string, Tuple<delegate,delegate>> getterSetterDict = new ...
    
        public GetValue(string key)
        {
            executeMyOnReadCode();
            return getterSetterDict[key].Item1();
        }
    
        public SetValue(string key)
        {
            executeMyOnWriteCode();
            getterSetterDict[key].Item2();
        }
    }
