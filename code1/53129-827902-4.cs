    class Program
    {
        static void Main(string[] args)
        {
            using (DBWrapper wrapper = new DBWrapper())
            {
                wrapper.DoWork();
            }
        }
    }
