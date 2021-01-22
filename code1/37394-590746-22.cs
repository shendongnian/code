    public ObjectFactory
    {
        public static Base Create(string xml)
        {
            Base o = null;
    
            Base.Type t;
    
            // Extract Base.Type from xml
            switch(t)
            {
                case Base.Type.Derived:
                    o = new Derived();
                    o.FromXml(xml);
                break;
             }
    
            return o;
        }
    };
