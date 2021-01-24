    public interface IConsoleView {
        void Write(string stringToWrite);
        void WriteLine(string stringToWrite);
        string ReadLine(string prompt);
    }
