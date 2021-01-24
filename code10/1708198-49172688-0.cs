    public class FooService: BarService,  IFooService
    {
        public FooService(ILogService logservice): base(logservice)
        {
        }
        public virtual Foo GetEntity(string fieldName, string fieldValue)
        {
            //here goes the logic
        }
    }
