    public static IEnumerable<string> GetInterests(Customer customer)
    {
        foreach (Characteristic c in customer.Characteristics)
        {
            if (c.CharacteristicType == "Interest")
                yield return c.CharacteristicValue;
        }
    }
