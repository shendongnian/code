    static class NConv
    {
        static T? ToNullable<T>(string str) where T : struct
        {
            return (T?)(string.IsNullOrEmpty(str) ? default(T?) : Convert.ChangeType(str, typeof(T)));
        }
    
        static void HowTo()
        {
            double? myBonus = NConv.ToNullable<double>(null);
        }
    }
