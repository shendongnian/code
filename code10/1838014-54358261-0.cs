    public static class Extensions
    {
        public static void IfNotNull<T>(this T obj, Action<T> action)
        {
            if (obj == null)
                return;
            action(obj);
        }
    }
    Homework homework = isposted ? new Homework() : null;
    homework.IfNotNull(h => h.Id = 3);
    homework.IfNotNull(h => h.Name = "Draw an Apple");
