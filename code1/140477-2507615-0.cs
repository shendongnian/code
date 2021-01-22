    public abstract class MyAspect : OnMethodBoundaryAspect
    {
    }
    [MulticastAttributeUsage(..., 
          TargetMembersAttributes = MulticastAttributes.Public )]
    [AttributeUsage(AttributeTargets.Class)]
    public class ClassLevelAspect : MyAspect
    {
    }
    [MulticastAttributeUsage(..., 
         TargetMembersAttributes = MulticastAttributes.NonPublic )]
    [AttributeUsage(AttributeTargets.Method)]
    public class MethodLevelAspect : MyAspect
    {
    }
