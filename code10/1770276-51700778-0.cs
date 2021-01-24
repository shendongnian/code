    public enum Action{
      [MyValue(1)]
      JUMP,
    
      [MyValue(2)]
      CROUCH
    }
    
    [AttributeUsage(
       AttributeTargets.Field |
       AttributeTargets.Method |
       AttributeTargets.Property,
       AllowMultiple = true)]
    public class MyValueAttribute : System.Attribute{
      public string Value{get; private set}
    
      public MyValueAttribute(string value) => Value = value;
    }
