    public static class EnumExtensions{
            public static string GetValue(this Enum value)
            {
                var type = value.GetType();
                var name = Enum.GetName(type, value);
                if (name == null) return string.Empty;
                var field = type.GetField(name);
                if (field == null) return string.Empty;
                var attr = Attribute.GetCustomAttribute(field, typeof(MyValueAttribute)) as MyValueAttribute;
                return attr != null ? attr.Value: string.Empty;
            }
            public static string GetAnimationId(this Enum value)
            {
                var type = value.GetType();
                var name = Enum.GetName(type, value);
                if (name == null) return string.Empty;
                var field = type.GetField(name);
                if (field == null) return string.Empty;
                var attr = Attribute.GetCustomAttribute(field, typeof(MyValueAttribute)) as MyValueAttribute;
                return attr != null ? attr.AnimationId: string.Empty;
            }
    }
