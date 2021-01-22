    [Serializable]
    abstract class Command<T>
    {
        public abstract T Run();
    }
    class DoFooBar : Command<int>
    {
        public Other Other { get; set; }
        public Thing Thing { get; set; }
        public override int Run()
        {
            return Thing.DoFoo() + Other.DoBar(); 
        }
    }
