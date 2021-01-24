    class Program
    {
        static void Main(string[] args)
        {
            var date = new DateTime(2018, 09, 18, 12, 00, 00);
            var guid = date.ToGuid();
            Console.WriteLine(guid); // 428a6000-1d5e-08d6-0000-000000000000
            var back2date = guid.ToDateTime();
            Console.WriteLine(back2date); // 9/18/2018 12:00:00
        }
    }
    public static class DateTimeExtensions
    {
        public static Guid ToGuid(this DateTime dt)
        {
            var bytes = BitConverter.GetBytes(dt.Ticks);
            Array.Resize(ref bytes, 16);
            return new Guid(bytes);
        }
    }
    public static class GuidExtensions
    {
        public static DateTime ToDateTime(this Guid guid)
        {
            var bytes = guid.ToByteArray();
            Array.Resize(ref bytes, 8);
            return new DateTime(BitConverter.ToInt64(bytes));
        }
    }
