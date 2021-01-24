    public interface ICsvRepo<T> : IRepository<T> where T : IBasic
    {
        IEnumerable<IBasic> GetRecords();
    }
    internal class CsvRepo<T> : ICsvRepo<T> where T : IBasic
    {
        private readonly ICsvSettings _settings;
        public CsvRepo(ICsvSettings settings)
        {
            _settings = settings;
        }
        public IEnumerable<IBasic> GetRecords()
        {
            return from line in File.ReadLines(_settings.Path)
                select line.Split(',') into parts
                where parts.Length == 3
                select new InputData { X = Convert.ToInt32(parts[1]), Y = Convert.ToInt32(parts[2]) };
        }
    }
