    public static class EventExtension
    {
        public static void RemoveEvents<T>(this T target) where T : Control
        {
           var propInfo = typeof(T).GetProperty("Events", BindingFlags.NonPublic | BindingFlags.Instance);
            var list = (EventHandlerList)propInfo.GetValue(target, null);
            list.Dispose();
        }
    }
