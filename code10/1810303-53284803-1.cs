    foreach (Task t in tasks)
    {
        Context  context = t.ConstructContext(condition);
    
        
    
        context.CommonProperty = "value";
        context.MethodToOverride();//Do different things based on the context type
    }
    
    public asbtract class Task
    {
        //whatever might be in here
        public abstract Context ConstructContext();
    }
    
    public class TaskA : Task
    {
        //NOTE: In my opinion condition should be internal to TaskA and no one else should know about and you should remove the parameter from the method
        // but I don't know where you get it from so I'm leaving it here
        public override Context ConstructContext(bool condition)
        {
            if (condition)
            {
                return new ContextA() { Task = this};
            }
            else
            {
                return new ContextA2() { Task = thid };
            }
        }
    }
    
    public class TaskB : Task
    {
        public override Context ConstructContext(bool condition)
        {
            //ignore condition which implies it shouldn't really be passed
    
            return new ContextB() {Task = this};
        }
    }
    
    //etc...
