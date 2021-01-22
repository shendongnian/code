    public IControl <T>GetControl()
    {
        switch (typeof(T).Name)
        {
            case "Bool":
                return new BoolControl();
            case "String":
                return new StringControl();
        }
        return null;
    }
