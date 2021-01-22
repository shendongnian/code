    class MyStaticInt
    {
        // Static storage
        private static Dictionary <string, int> staticData =
            new Dictionary <string, int> ();
        
        private string InstanceId
        {
            get
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (2);
                MethodBase mb = sf.GetMethod ();
                return mb.DeclaringType.ToString () + "." + mb.Name;
            }
        }
        public int StaticValue
        {
            get { return staticData[InstanceId]; }
    
            set { staticData[InstanceId] = value; }
        }
    
        public MyStaticInt (int initializationValue)
        {
            if (!staticData.ContainsKey (InstanceId))
                staticData.Add (InstanceId, initializationValue);
        }
    }
