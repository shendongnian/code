    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class RepositoryAttribute : Attribute
    {
        public RepositoryAttribute(Type repositoryType)
        {
            this.RepositoryType = repositoryType;
        }
        public Type RepositoryType { get; private set; }
    }
