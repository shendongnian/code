    public static List<T> SearchList<T>(this List<T> list, string PropertyName, string SearchValue)
    {
        return list.Select(item =>
            new
            {
                i = item,
                Props = item.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public)
            })
            .Where(item => item.Props.Any(p =>
            {
                var val = p.GetValue(item.i, null);
                return val != null
                    && (p.Name.ToLower() == PropertyName.ToLower() || string.IsNullOrEmpty(PropertyName))
                    && (val.ToString().ToLower().Contains(SearchValue.ToLower()) || string.IsNullOrEmpty(SearchValue));
            }))
            .Select(item => item.i)
            .ToList();
        }
