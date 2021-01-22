    public interface IBase {
      string ErrorMessage { get; set; }
      void AddData();
      void DeleteData();
    }
    public abstract class AbstractBase : IBase {
      abstract string ErrorMessage { get; set; }
      // also, you need to declare a return type for the methods
      abstract void AddData();
      abstract void DeleteData();
    }
