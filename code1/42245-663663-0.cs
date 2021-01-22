    public interface IAmReal
    {
        void DoThatThingYouDo();
        ...
    }
    abstract class GenericBase<T> : IAmReal
    {
        protected GenericBase<T>(T arg)
        {
            Arg = arg;
        }
        public T Arg { get; set; }
        public abstract void DoThatThingYouDo();
    }
    class MyConcrete : GenericBase<string>
    {
        public MyConcrete(string s) : base(s) {}
        public override void DoThatThingYouDo()
        {
            char[] chars = Arg.ToLowerInvariant().ToCharArray();
            ...
        }
    }
    class Usage
    {
        public void UseIt()
        {
            IAmReal rb = new MyConcrete( "The String Arg" );
            DoTheThing(rb);
        }
        private void DoTheThing(IAmReal thingDoer)
        {
            rb.DoThatThingYouDo();
        }
    }
