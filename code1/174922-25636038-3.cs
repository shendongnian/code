    namespace MyApp.Model
    {
        // using statements found here
        public partial class MyDbContext : DbContext
        {
            public MyDbContext()
                : base("name = MyDbContext")
            { }
            public virtual ObjectResult<string> Decrypt(byte[] encryptedData)
            {
                var encryptedDataParameter = encryptedData != null ? 
                                new ObjectParameter("encryptedData", encryptedData) :
                                new ObjectParameter("encryptedData", typeof(byte[]));
                return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("Decrypt", encryptedDataParameter);
            }
            // similar function for Encrypt 
        }
    }
