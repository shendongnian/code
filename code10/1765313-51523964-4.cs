    public class HistogramWithIndex
    {
        public HistogramWithIndex(IEnumerable<int> histogram, int index)
        {
            Histogram = histogram;
            Index = index;
        }
        public IEnumerable<int> Histogram { get; }
        public int Index { get; }
    }
    public class IndexWithHistogramSize
    {
        public IndexWithHistogramSize(int index, int histogramSize)
        {
            Index = index;
            HistogramSize = histogramSize;
        }
        public int Index { get; }
        public int HistogramSize { get; }
    }
