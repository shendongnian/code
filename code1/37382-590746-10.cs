    public ObjectFactory
    {
        public static Base Create(string xml)
        {
            Base o = null;
    
            Base.Type t;
    
            // Extract Base.Type from xml
            switch(t)
            {
                base Base.Derived:
                    o = Derived();
                    o.FromXml(xml);
                break;
             }
    
            return o;
        }
    };
