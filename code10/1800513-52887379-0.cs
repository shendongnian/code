    IntuneMAMPolicyManager value = IntuneMAMPolicyManager.Instance;
    NSDictionary dictionary =  value.DiagnosticInformation;
    NSString[] keys = new NSString[]
    {
        new NSString("AppConfig")
    };
    NSDictionary key= dictionary.GetDictionaryOfValuesFromKeys(keys);
    var field1 = new NSObject();
    var field2 = new NSObject();
    for (int i = 0, keyCount = (int)key.Count; i < keyCount; i++)
    {
        var author = key.ElementAt(i);
        NSObject fields_values = author.Value;
        field1 =  fields_values.ValueForKey(new NSString("field1"));
        field2 =  fields_values.ValueForKey(new NSString("field2"));
        Console.WriteLine("field1: {0}, field2: {1}", field1.ToString(), field2.ToString());
       
    }
