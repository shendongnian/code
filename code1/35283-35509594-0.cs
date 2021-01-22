    public class ExitMyForEachListException : Exception
    {
        public ExitMyForEachListException(string message)
            : base(message)
        {
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<string> str = new List<string>() { "Name1", "name2", "name3", "name4", "name5", "name6", "name7" };
            try
            {
                str.ForEach(z =>
                {
                    if (z.EndsWith("6"))
                        throw new ExitMyForEachListException("I get Out because I found name number 6!");
                    System.Console.WriteLine(z);
                });
            }
            catch (ExitMyForEachListException ex)
            {
                System.Console.WriteLine(ex.Message);
            }
            System.Console.Read();
        }
    }
