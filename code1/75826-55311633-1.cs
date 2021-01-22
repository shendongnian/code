    public CustomObject CreateNewCustomObject(BaseObject obj, string ANewProp, bool ExtraBool)
    {
        return new CustomObject(obj)
        {
            ANewProperty = ANewProp,
            ExtraBooleanField = ExtraBool
        };
    }
