       public ExampleDBObjectContext(string connectionString) : base(connectionString, "publicExampleDBObjectContext")
		{
            this.SavingChanges += new EventHandler(UpdateAuditInformation);
            this.OnContextCreated();
         }
