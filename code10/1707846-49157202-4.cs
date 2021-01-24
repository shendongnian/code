    public class MyContainer
    {
        private readonly Service singleton = new Service();
        public Application Resolve()
        {
            return new Application(
                singleton: this.singleton, 
                transient: new Service());
        }
    }
