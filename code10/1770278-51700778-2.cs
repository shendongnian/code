    public enum Action{
      [MyValue("JUMP", 1)]
      JUMP,
    
      [MyValue("CROUCH", 2)]
      CROUCH
    }
    
    [AttributeUsage(
       AttributeTargets.Field |
       AttributeTargets.Method |
       AttributeTargets.Property,
       AllowMultiple = true)]
    public class MyValueAttribute : System.Attribute{
      public string Value{get; private set}
      public string AnimationId{get; private set;}
      public MyValueAttribute(string animationId, string value){
         AnimationId = animationId;
         Value = value;
    }
