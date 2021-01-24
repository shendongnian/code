    internal abstract class LowerCommand<T> {
        public abstract void Execute();
        public abstract List<T> ExecuteList();
    }
    
    // Note that HigherCommand require a declaration of `T`
    internal abstract class HigherCommand<T> : Lowercommand<T> {
        // ... defines other stuff, nothing to do with
        //     already instantiated methods or T ...
    }
    
    class ListResults : HigherCommand<Results>
    {
        public override void Execute() {...}
        public override List<Results> ExecuteList() {...}
    }
