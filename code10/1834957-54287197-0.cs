    public interface ISbFactory
    {
        Sb Create();
    }
    public class SbFactory : ISbFactory
    {
        private readonly Sa _sa;
        public SbFactory(Sa sa) => _sa = sa;
        public Sb Create()
        {
            var token = _sa.GrantToken();
            return new Sb(token);
        }
    }
