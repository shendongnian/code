    public class PrecipitationFile
    {
        string FileName { get; }
        public IList<PrecipitationGrid> Grids { get; }
        int BoxCount { get; }
        double Multi { get; }
        int Missing { get; }
        IList<string> Years { get; }
        public PrecipitationFile(string filePath)
        {
            // Read file, set properties, split by grid-ref chunks
            // Grids.Add(new PrecipitationGrid(this, chunk));
        }
    }
    public class PrecipitationGrid
    {
        int Id { get; }
        int Ref { get; }
        PrecipitationFile Header { get; }
        string Source { get; }
        IList<int> GridNumbers { get; set; }
        public PrecipitationGrid(PrecipitationFile header, string source)
        {
            // set properties
        }
    }
