    public abstract class SqlStatement
        {
            protected List<string> properties;
            protected object item;
            protected string sql;
    
            public SqlStatement(List<string> properties) 
            {
                this.properties = properties;
            }
    
            protected abstract void Initialize();
    
            public virtual void Execute()
            {
                Console.WriteLine("Sending to database: " + sql);
            }
        }
