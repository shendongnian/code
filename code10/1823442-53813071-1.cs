      public class TestMongoRepository: BaseMongoRepository, IEmailMongoRepository
        {
            public TestMongoRepository(string connectionString, string databaseName) : base(connectionString, databaseName)
            {
    
            }
            //public MongoRepository<T> Create<T>() where T:IEntity
            //{
            //    return new MongoRepository<T>();
            //}
        }
    }
      public class Data: Document
        {
           
            public string Sender { get; set; }
           public string Receiver{ get; set; }
    
    }
