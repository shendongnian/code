    public class FooWithExtraInfoService: FooService
    {
        public FooWithExtraInfoService(ILogService logservice): base(logservice)
        {
        }
        public override Foo GetEntity(string fieldName, string fieldValue)
        {
            Foo foo = base.GetEntity(fieldName, fieldValue)
            //do additional stuff
            foo.SomeField = "abc";
        }
    }
