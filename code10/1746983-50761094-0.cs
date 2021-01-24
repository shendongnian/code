    [Flags]
    public enum Features
    {
        None    = 0,
        IsPipe = 1,
        IsSomething = 2,
        IsSomethingElse = 4
    }
    public class MyProduct
    {
        public Features VersionFeatures
        {
            get
            {
                return Features.IsPipe | Features.IsSomethingElse;
            }
        }
    }
