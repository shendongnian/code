    public class TemporaryDataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var option = new DbContextOptionsBuilder<DataContext>()
            .UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Database=IbReport;Integrated Security=SSPI").Options;
            return new DataContext(option);
        }
    }
