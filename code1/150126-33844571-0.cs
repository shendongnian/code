    namespace Parent {
      public class Constants
      {
        // adjust
        public const string LIB_PATH = @"d:\temp\TestLibrary.dll";
      }
      public interface ILoader
      {
        string Execute();
      }
      public class Loader : MarshalByRefObject, ILoader
      {
        public string Execute()
        {
            var assembly = Assembly.LoadFile(Constants.LIB_PATH);
            return assembly.FullName;
        }
      }
      class Program
      {
        static void Main(string[] args)
        {
          var domain = AppDomain.CreateDomain("child");
          var loader = (ILoader)domain.CreateInstanceAndUnwrap(typeof(Loader).Assembly.FullName, typeof(Loader).FullName);
          Console.Out.WriteLine(loader.Execute());
          AppDomain.Unload(domain);
          File.Delete(Constants.LIB_PATH);
        }
      }
    }
