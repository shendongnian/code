    public interface IOutputWriter
    {
        void WriteLine(string line);
    }
    
    public class ConsoleWriter : IOutputWriter
    {
        public void WriteLine(string line)
        {
            Console.WriteLine(line);
        }
    }
