    public class DynamicInvoker : IDynamicObject
        {
            public MetaObject GetMetaObject
                  (System.Linq.Expressions.Expression parameter)
            {
                return new DynamicReaderDispatch (parameter);
            }
        }
    
        public class DynamicDispatcher : MetaObject
        {
            public DynamicDispatcher (Expression parameter) 
                       : base(parameter, Restrictions.Empty){ }
    
            public override MetaObject Call(CallAction action, MetaObject[] args)
            {
                //You'll get MyMethod1 and MyMethod2 here (and what ever you call)
                Console.WriteLine("Logic to invoke Method '{0}'", action.Name);
                return this; //Return a meta object
            }
        }
