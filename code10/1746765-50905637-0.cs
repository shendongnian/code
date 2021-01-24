    public class Class1
    {
        private readonly IIndex<string, Context> contexts;
        public Class1(IIndex<string, Context> contexts)
        {
             this.contexts = contexts;
        }
        public void Whatever()
        {
            string action = ...; // platform, replica or temp
            Context context = this.contexts[action];
            ...
        }
    }
