    static void TraverseProperties(JToken jtoken)
    {
        foreach (var value in jtoken.Values())
        {
            if (!value.HasValues)
            {
                Console.WriteLine(value.Path + ": " + value.ToObject<string>());
            }
            else
            {
                TraverseProperties(value);
            }
        }
    }
    TraverseProperties(obj1);
