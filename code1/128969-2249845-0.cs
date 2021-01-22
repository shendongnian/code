    public class MyArticleFactory
    {
        private Dictionary<string, Func<IArticle>> instantiators =
            new Dictionary<string, Func<Iarticle>>();
        public MyArticleFactory()
        {
            Register("Jeans", () => new Jeans());
            Register("Shirt", () => new Shirt());
            // etc.
        }
        public IArticle CreateArticle(string sku)
        {
            Func<IArticle> instantiator;
            if (creators.TryGetValue(sku, out instantiator))
                return instantiator();
        }
        protected void Register(string sku, Func<IArticle> instantiator)
        {
            creators.Add(sku, instantiator);
        }
    }
