    public class UnityOfWork : IUnityOfWork
        {
            private MySqlContext mySqlContext;
            private ApplicationContext applicationContext;
            private MsSqlReadOnlyContext msSqlReadOnlyContext;
    
            public UnityOfWork(
                 ApplicationContext applicationContext,
                 MsSqlReadOnlyContext msSqlReadOnlyContext,
                 MySqlContext mySqlContext // <-- When I put on the first place - there is an error of definition of factory!
                )
            {
                this.mySqlContext = mySqlContext;
                this.applicationContext = applicationContext;
                this.msSqlReadOnlyContext = msSqlReadOnlyContext;
            }
    }
