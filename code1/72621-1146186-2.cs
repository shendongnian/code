    // boxes if needed
    public interface IGeneralValue
    {
        object Value { get; }
        Type GetValueType();
    }
    public class Value<T> : IGeneralValue
    {
         public T Value { get; set;}
         object IGeneralValue.Value 
         {
             get { return (object)this.Value; }
         } 
         public Type GetValueType()
         {
             return typeof(T);
         }
    }
