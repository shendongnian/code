    public interface IApplication
    {
      Uri Address{ get; set; }
      void ConnectTo(Uri address);
    }
    public class App : Application, IApplication
    {
      // code removed for brevity
    }
