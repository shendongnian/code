    public class ConcreteIdea : BaseIdea {}
    public class ModuleBaseLogic {
      public void Sponsor<T>(int id) 
      where T : BaseIdea, new() 
      {
        // Do something
      }
    }
    
    public class Caller {
      protected static MethodInfo GetMethod<T>(Expression<Action<T>> expr)
      {
        return ((MethodCallExpression)expr.Body).Method.GetGenericMethodDefinition();
      }
    
      public Caller() { 
        int id = 1;
        MethodInfo method = GetMethod<ModuleBaseLogic>(q => q.Sponsor<ConcreteIdea>(id));
      }
    }
