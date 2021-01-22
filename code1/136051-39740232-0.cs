    public static bool IsSingle(this Enum value)
        {
            var items = Enum.GetValues(value.GetType());
            var counter = 0;
            foreach (var item in items)
            {
                if (value.HasFlag((Enum)item))
                {
                    counter++;
                }
                if (counter > 1)
                {
                    return false;
                }
            }
            return true;
        }
