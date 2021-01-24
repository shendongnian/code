    public static void CopyFrom<T, U>(ref this T target, U source)
    {
         bool isValidString = (source is string && source != null && !string.IsNullOrEmpty(source.ToString()));
         bool isValidNonString = (!(source is string) && source != null);
         if (isValidString || isValidNonString)
             target = Utils.GetValue<T>(source);
    }
