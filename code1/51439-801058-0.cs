        public enum Family
        {
            Brother,
            Sister,
            Father
        }
        public enum CarType
        {
            Volkswagen,
            Ferrari,
            BMW
        }
        static void Main(string[] args)
        {
            Console.WriteLine(GetEnumList<Family>());
            Console.WriteLine(GetEnumList<Family>().First());
            Console.ReadKey();
        }
        private static List<T> GetEnumList<T>()
        {
            T[] array = (T[])Enum.GetValues(typeof(T));
            List<T> list = new List<T>(array);
            return list;
        }
