    public interface IProgressReporter
    {
           void ReportMessage(string message);
    }
    public class WinFormsProgressReporter : IProgressReporter
    {
        public void ReportMessage(string message)
        {
              MessageBox.SHow(message);
        }
    }
    public class ConsoleAppProgressReporter : IProgressReporter
    {
        public void ReportMessage(string message)
        {
              Console.WriteLine(message);
        }
    }
    public class LibraryClass
    {
        public static void SomeMethod(IProgressReporter rep)
        {
             rep.ReportMessage("Wooooohooooo!");
        }
    }
