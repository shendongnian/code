    public static class Foo
    {
        public static void Bar()
        {
            var now = DateTime.Now;
            var tomorrow = typeof(DateTime).Tomorrow();
        }
        public static DateTime Tomorrow(this System.Type type)
        {
            if (type == typeof(DateTime)) {
                return DateTime.Now.AddDays(1);
            } else {
                throw new InvalidOperationException();
            }
        }
    }
