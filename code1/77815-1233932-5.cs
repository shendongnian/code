        public const string UnitTestConnection = "Data Source=.;Initial Catalog=MyAppUnitTest;Integrated Security=True";
        
        [FixtureSetUp()]
        public void Setup()
        {
          OARsDataContext context = new MyAppDataContext(UnitTestConnection);
        
          if (context.DatabaseExists())
          {
            Console.WriteLine("Removing exisitng test database");
            context.DeleteDatabase();
          }
          Console.WriteLine("Creating new test database");
          context.CreateDatabase();
             
          context.SubmitChanges();
        }
