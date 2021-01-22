    public class Test
    {
        void DoSomething<T>(T value) where T : IConvertible
        {
            var type = typeof(T);
            if (type == typeof(int))
            {
                int y = value.ToInt32(CultureInfo.CurrentUICulture);
            }
        }
    }
