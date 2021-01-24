    for (int i = 0; i < filters.Count; i++)
    {
        string filterName = filters.GetKey(i);
        string filterValue = filters[i];
        PropertyDescriptor propDescriptor = typeDescriptor[filterName];
        if (propDescriptor == null)
            continue;
        else
        {
            string propValue = propDescriptor.GetValue(obj).ToString();
            bool isMatch = Regex.IsMatch(propValue, $"({filterValue})");
            if (isMatch)
                return true;
            else
                continue;
        }
    }
