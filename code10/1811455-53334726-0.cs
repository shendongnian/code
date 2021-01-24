    // Dictionary.Item property we will use to get/set values
    var itemProp = target.GetType().GetProperty("Item");
    // Since you want to modify dictionary while enumerating it's items (which is not allowed),
    // you have to use .Cast<object>().ToList() to temporarily store all items in the list
    foreach (var item in (target as IEnumerable).Cast<object>().ToList())
    {
        // item is of type KeyValuePair<TKey,TValue> and has Key and Value properties.
        // Use reflection to read content from the Key property
        var itemKey = item.GetType().GetProperty("Key").GetValue(item);
        Action<Object> valueSetter = (val) => itemProp.SetValue(target, val, new object[] { itemKey });
        // valueSetter(someNewValue);
        // It's not possible to just change the key of some item. As a workaround,
        // you have to remove original item from the dictionary and insert a new item
        // with the original value and with a new key.
        Action<Object> keySetter = (key) =>
        {
            // read value from the dictionary for original key
            var val = itemProp.GetValue(target, new object[] { itemKey });
            // set this value to the disctionary with the new key
            itemProp.SetValue(target, val, new object[] { key });
            // remove original key from the Dictionary
            target.GetType().GetMethod("Remove").Invoke(target, new Object[] { itemKey });
            // need to "remember" the new key to allow the keySetter to be called repeatedly
            itemKey = key;
        };
        // keySetter(someNewKey);
    }
