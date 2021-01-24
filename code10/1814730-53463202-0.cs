    public static readonly LoggerFactory MyLoggerFactory
        = new LoggerFactory(new[] {new ConsoleLoggerProvider((_, __) => true, true)});
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder
            .UseLoggerFactory(MyLoggerFactory) // Warning: Do not create a new ILoggerFactory instance each time
            .UseSqlServer(...);
