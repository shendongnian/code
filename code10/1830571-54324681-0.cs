    public DbSet<T> : IEnumerable<T> where T: class
    {
        public FileInfo CsvFile {get; set;}
        public IEnumerator<T> GetEnumerator()
        {
            return this.ReadCsvFile().GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        protected IEnumerable<T> ReadCsvFile()
        {
            // open the CsvFile, read the lines and convert to objects of type T
            // consider using Nuget package CsvHelper
            ...
            foreach (var csvLine in csvLines)
            {
                T item = Create<T>(csvLine); // TODO: write how to convert a line into T
                yield return T;
            }
        }
    }
 
