    public partial class AccountViewModel
    {
        internal class AccountViewModelMetaData
        {
            public virtual Int32 ID { get; set; }
            [ReadOnlyAttribute(false)]
            public virtual decimal Balance { get; set; }
        }
    
        public virtual Int32 ID { get; set; }
        public virtual decimal Balance { get; set; }
    }
    class Program
    {
        public static void Main(string[] args)
        {
            Type metaClass = typeof(AccountViewModel.AccountViewModelMetaData);
    
            bool hasReadOnlyAtt = HasReadOnlyAttribute(metaClass, "Balance");
    
            Console.WriteLine(hasReadOnlyAtt);
        }
    
        private static bool HasReadOnlyAttribute(Type type, string property)
        {
            PropertyInfo pi = type.GetProperty(property);
    
            return ReadOnlyAttribute.IsDefined(pi, typeof(ReadOnlyAttribute));
        }
    }
