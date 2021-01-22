    class Program
    {
        enum CourseType
        {
            Unknown = 0,
            Fulltime = 1,
            Parttime = 2
        }
        static void Main(string[] args)
        {
            var i = 1;
            Console.WriteLine("Coursetype: {0}", ((CourseType)i).ToString());
        }
    }
