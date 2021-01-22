    public static string GetDisplayName(this Enum enumValue)
        {
            var enumMember = enumValue.GetType().GetMember(enumValue.ToString()).First();
            return enumMember.GetCustomAttribute<DisplayAttribute>() != null ? enumMember.GetCustomAttribute<DisplayAttribute>().Name : enumMember.Name;
        }
