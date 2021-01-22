    foreach (Property propertyItem in item.Properties)
    {
        if (!propertyItem.IsReadOnly)
        {
            Console.WriteLine(String.Format("{0}\t{1}\t{2}", propertyItem.Name, propertyItem.PropertyID, propertyItem.get_Value()));
        }
    }
