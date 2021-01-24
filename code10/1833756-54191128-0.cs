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
            char[] myCharArray = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
            if (s.Any(s.Contains))
            {
                throw new FormatException();
            }
        }
    }
