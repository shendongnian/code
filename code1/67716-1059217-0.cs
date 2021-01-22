    foreach (Item item in items)
    {
        Boolean found = false;
        foreach (String keyword in keywords)
        {
            found = false;
            foreach (SubItem subItem in item.SubItems)
            {
                if (subItem.StringValue.Contains(keyword))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                break;
            }
        }
        if (found)
        {
            result.Add(item);
        }
    }
