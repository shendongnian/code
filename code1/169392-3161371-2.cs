    public class ConsoleWrapper : IConsole
    {
        public List<String> LinesToRead = new List<String>();
        public void Write(string message)
        {
        }
        public void WriteLine(string message)
        {
        }
        public string ReadLine()
        {
            string result = LinesToRead[0];
            LinesToRead.RemoveAt(0);
            return result;
        }
    }
