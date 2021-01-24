    class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student();
            try
            {
                Console.Write("First name: ");
                student.FirstName = Console.ReadLine();
                ValidateMyString(student.FirstName);
                Console.ReadLine();
            }
            catch(Exception e)
            {
                throw e;
            }
        }
    
        static void ValidateMyString(string s)
        {
            if (s.Any(char.IsDigit))
            {
                throw new FormatException();
            }
        }
    }
