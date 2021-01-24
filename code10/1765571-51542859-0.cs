    public class NumberFactory : INumberFactory
    {
        readonly IResolutionRoot resolutionRoot;
    
        public NumberFactory(IResolutionRoot resolutionRoot)
        {
            this.resolutionRoot = resolutionRoot;
        }
     
        Test INumberFactory.Create(int a)
        {
            return this.resolutionRoot.Get<Test>(
                new ConstructorArgument("a", a));
        }
    }
