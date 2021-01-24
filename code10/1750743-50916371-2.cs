    static void TraverseJToken(JToken jtoken)
    {
        foreach (var value in jtoken.Values())
        {
            if (value.HasValues)
            {
                TraverseJToken(value);
            }
            else
            {
                Console.WriteLine(value.Path + ": " + value.ToObject<string>());
            }
        }
    }
    TraverseJToken(root);
