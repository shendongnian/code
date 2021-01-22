    using (IAnnouncer announcer = new TextWriterAnnouncer(Console.Out))
    {
       IRunnerContext migrationContext = new RunnerContext(announcer) 
       { 
          Connection = "Data Source=test.db;Version=3", 
          Database = "sqlite", 
          Target = "migrations" 
       };
       TaskExecutor executor = new TaskExecutor(migrationContext);
       executor.Execute();
    }
