    public Privilege this[int key]
    {
        get
        {
            var value = (Privilege)null;
            if(!_privileges.TryGetValue(key, out value))
                value = new Privilege();
            return value;
        }
    }
