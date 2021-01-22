    public abstract ActionClass<T>
    {
        public abstract int DoAction(T parameter);
    }
    
    public class ActionClass2 : ActionClass<string>
    {
        public override int DoAction(string parameter) { ... }
    }
