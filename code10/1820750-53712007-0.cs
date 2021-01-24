    public static void CopyFieldsTo<T, TU>(this T source, TU dest)
    {
        var sourceFields = typeof(T).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
        var destFields = typeof(TU).GetFields(BindingFlags.NonPublic | BindingFlags.Instance).ToList();
        foreach (var sourceField in sourceFields)
        {
            if (destFields.Any(x => x.Name == sourceField.Name))
            {
                var f = destFields.First(x => x.Name == sourceField.Name);
                f.SetValue(dest, sourceField.GetValue(source, null), null);
            }
        }
    }
