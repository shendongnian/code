    partial class MyDataContextDataContext
    {
        [Function(Name = "NEWID", IsComposable = true)]
        public Guid Random()
        {
            throw new NotImplementedException();
        }
        public string GetRandomUrl()
        {
            return randomUrl(this);
        }
        static readonly Func<MyDataContextDataContext, string>
            randomUrl = CompiledQuery.Compile(
            (MyDataContextDataContext ctx) =>
                     (from s in ctx.seos
                     from i in ctx.indexes
                     where i.key <= s.weight
                     orderby ctx.Random()
                     select s.url).First());
    }
