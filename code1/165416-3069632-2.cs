    public class NewClass : BaseClass
    {
        protected new static ConsoleWriter consoleWriter = new ConsoleWriter(">");
        
        public static new void Write(string text)
        {
            consoleWriter.Write(text);
        }
    }
