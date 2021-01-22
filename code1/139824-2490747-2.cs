    static List<Mammal> ReCalculateDOB(List<Mammal> list)
    {
        foreach (var item in list)
        {
            var properties = item.GetType().GetProperties();
            foreach (var property in properties)
            {
                if (property.PropertyType == typeof(DateTime))
                    property.SetValue(item, ((DateTime)property.GetValue(item, null)).AddDays(10), null);
            }
        }
        return list;
    }
