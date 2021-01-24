    foreach (var obj1 in object1)
    {
        obj1.Exclude = true;
        foreach (var obj2 in object2)
        {
            if (obj1.Value1.Equals(obj2.Value1)
                || obj1.Value1.Equals(obj2.Value2)
                || obj1.Value2.Equals(obj2.Value1)
                || obj1.Value2.Equals(obj2.Value2))
            {
                obj1.Exclude = false;
                break;
            }
        }
    }
