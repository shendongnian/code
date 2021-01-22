     if (aProp.Name == bProp.Name)
        {
            if (aProp.PropertyType.IsArray)
            {
                MapDataObjects(aProp.PropertyType.GetElementType(), bProp.PropertyType.GetElementType());
                seenTypes.Add(aProp.PropertyType.GetElementType());
                break;
            }
            else
            {
                MapDataObjects(aProp.PropertyType, bProp.PropertyType);
                seenTypes.Add(aProp.PropertyType);
                break;
            }
        }
