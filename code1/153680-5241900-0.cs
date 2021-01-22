        CoreExtensions.Host.InitializeService();
        SimpleTestRunner runner = new SimpleTestRunner();
        TestPackage package = new TestPackage( "Test" );
        string loc = Assembly.GetExecutingAssembly().Location
        package.Assemblies.Add( loc );
        if( runner.Load(package) )
        {
            TestResult result = runner.Run( new NullListener() );
        }
    }
