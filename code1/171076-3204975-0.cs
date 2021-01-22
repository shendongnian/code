    private static Dictionary<int, string> _FieldLookup;
    public static bool TryGetErrorName(int result, out string errorName)
    {
        if (_FieldLookup == null)
        {
            Dictionary<int, string> tmpLookup = new Dictionary<int, string>();
            FieldInfo[] fields = typeof(ResultWin32).GetFields();
            foreach (FieldInfo field in fields)
            {
                int errorCode = (int)field.GetValue(null);
                tmpLookup.Add(errorCode, field.Name);
            }
            _FieldLookup = tmpLookup;
        }
        return _FieldLookup.TryGetValue(result, out errorName);
    }
