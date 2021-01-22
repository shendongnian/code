    public class FieldByType
    {
        static class Storage<T>
            where T : class
        {
            static readonly ConditionalWeakTable<FieldByType, T> table = new ConditionalWeakTable<FieldByType, T>();
            public static T GetValue(FieldByType fieldByType)
            {
                table.TryGetValue(fieldByType, out var result);
                return result;
            }
            public static void SetValue(FieldByType fieldByType, T value)
            {
                table.Remove(fieldByType);
                table.Add(fieldByType, value);
            }
        }
        public T GetValue<T>()
            where T : class
        {
            return Storage<T>.GetValue(this);
        }
        public void SetValue<T>(T value)
            where T : class
        {
            Storage<T>.SetValue(this, value);
        }
    }
