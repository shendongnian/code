    foreach (object item in list)
    {
           IEnumerable<object> itemAsObjectEnumerable = (IEnumerable<object>)item;
           IEnumerable<int> itemAsIntEnumerable = itemAsObjectEnumerable.Cast<int>();
           foreach (var i in itemAsIntEnumerable)
           {
                print(i);
           }
    }
