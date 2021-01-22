    public static class Helper
        {
            public static object GetPropertyValue(this object T, string PropName)
            {
                return T.GetType().GetProperty(PropName) == null ? null : T.GetType().GetProperty(PropName).GetValue(T, null);
            }
        }
