    public static class StructFactory
    {
        public static Value DefaultValue()
        {
             Value v = new Value();
             v.Value = 0.0;
             v.Accuracy = 15; /* digits */
             return v;
        }
    }
     
    ...
     
    Value v = StructFactory.DefaultValue();
