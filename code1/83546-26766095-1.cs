    public class MyContext: BaseDbContext<MyEntities>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MyContext"/> class.
        /// </summary>
        public MyContext()
            : base("name=MyConnectionString")
        {
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="MyContext"/> class.
        /// </summary>
        /// <param name="connectionString">The connection string.</param>
        public MyContext(string connectionString)
            : base(connectionString)
        {
        }
         //DBcontext class body here (methods, overrides, etc.)
     }
