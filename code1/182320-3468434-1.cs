    class ObjectAType
    {
        public int PropertyC
        {
            get
            {
                if (PropertyA == null)
                    return 0;
                if (PropertyA.PropertyB == null)
                    return 0;
                return PropertyA.PropertyB.PropertyC;
            }
        }
    }
    
    
    
    if (ObjectA != null)
    {
        int value = ObjectA.PropertyC;
        ...
    }
