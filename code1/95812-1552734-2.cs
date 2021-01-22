    public string MyClassToJson(MyClass mc)
    {
        JavaScriptSerializer serializer = new JavaScriptSerializer();
        string serializedObject = serializer.Serialize(mc);
        return serializedObject;
    }
