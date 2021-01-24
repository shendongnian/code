    internal abstract class CsvRepo<T> : ICsvRepo<T> where T : IBasic
    {
        public CsvRepo()
        {
        }
        public abstract IEnumerable<T> GetRecords();
    }
    internal class InputDataCsvRepo : CsvRepo<InputData1>
    {
        public override IEnumerable<InputData1> GetRecords()
        {
            return from line in File.ReadLines(_settings.Path)
                   select line.Split(',') into parts
                   where parts.Length == 3
                   select new InputData { X = Convert.ToInt32(parts[1]), Y = Convert.ToInt32(parts[2]) };
        }
    }
