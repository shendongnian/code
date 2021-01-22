    public abstract class Form<T>{
      public string FormName;
      public IList<IFormField> Fields;
    }
    
    public class FormField<T> : IFormField{
      public T getValue { ... code here ...  }
    }
    
    public interface IFormField { }
