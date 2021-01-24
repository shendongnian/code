    public static List<SelectListItem> ToOrderedSelectList<TEnum>() where TEnum : struct, IConvertible
    {
        return Enum.GetValues(typeof(TEnum)).Cast<TEnum>()
            .Select(@enum => new
            {
                enumValue = GetValue(@enum),
                order = GetDisplayOrder(@enum),
                enumText = GetDisplayName(@enum)
            })
            .OrderBy(x => x.order)
            .Select(x => new SelectListItem
            {
                Text = x.enumText,
                Value = x.enumValue
            }
        ).ToList();
    }
    private static int GetDisplayOrder<TEnum>(TEnum @enum) where TEnum : struct, IConvertible
    {
        return @enum.GetType().GetMember(@enum.ToString()).FirstOrDefault()?
                    .GetCustomAttribute<DisplayAttribute>(false)?.Order ?? 0;
    }
