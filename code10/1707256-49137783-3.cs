    public class Series<T>
    {
        public List<T> Data { get; set; }
    }
    public class BloxPlotSeriesData
    {
        [JsonMinify]
        public double Low { get; set; }
        [JsonMinify]
        public double Q1 { get; set; }
        [JsonMinify]
        public double Median { get; set; }
        [JsonMinify]
        public double Q3 { get; set; }
        [JsonMinify]
        public double High { get; set; }
        [JsonMinify]
        public string Color { get; set; }
    }
    /// <summary>
    /// The base class, holding common drawing data.
    /// </summary>
    public abstract class GraphData
    {
        private const string CaptivePlotColor = "#C111A0";
        private const string ParentPlotColor = "#FFB81C";
        [JsonMinify]
        public List<double> CaptiveView { get; set; }
        [JsonMinify]
        public List<double> ParentView { get; set; }
        /// <summary>
        /// Override this method in subclasses if you needto provide additional data.
        /// </summary>
        /// <returns>More data to be plotted.</returns>
        public virtual BloxPlotSeriesData ReturnMoreData()
        { return null; }
        /// <summary>
        /// Returns plot data.
        /// </summary>
        /// <returns>Plot data.</returns>
        public Series<BloxPlotSeriesData> GenerateBoxPlotChartSeries()
        {
            BloxPlotSeriesData captiveViewSeriesData = GetCaptivePlotData();
            BloxPlotSeriesData parentViewSeriesData = GetParentData();
            var Result = new Series<BloxPlotSeriesData>
            {
                Data = new List<BloxPlotSeriesData> { captiveViewSeriesData, parentViewSeriesData }
            };
            return AddMoreData(Result);
        }
        /// <summary>
        /// Adds more data if the first argument can provide it.
        /// </summary>
        /// <param name="Result"></param>
        /// <returns></returns>
        private Series<BloxPlotSeriesData> AddMoreData(Series<BloxPlotSeriesData> Result)
        {
            var MoreData = ReturnMoreData();
            if (MoreData != null)
            {
                Result.Data.Add(MoreData);
            }
            return Result;
        }
        private BloxPlotSeriesData GetParentData()
        {
            return new BloxPlotSeriesData
            {
                Low = ParentView[0],
                Q1 = ParentView[1],
                Median = ParentView[2],
                Q3 = ParentView[3],
                High = ParentView[4],
                Color = ParentPlotColor
            };
        }
        private BloxPlotSeriesData GetCaptivePlotData()
        {
            return new BloxPlotSeriesData
            {
                Low = CaptiveView[0],
                Q1 = CaptiveView[1],
                Median = CaptiveView[2],
                Q3 = CaptiveView[3],
                High = CaptiveView[4],
                Color = CaptivePlotColor
            };
        }
    }
    public class EVAGraphData : GraphData
    {
    }
    public class NPVGraphData : GraphData
    {
        [JsonMinify]
        public List<double> SelfIns { get; set; }
        public override BloxPlotSeriesData ReturnMoreData()
        {
            return new BloxPlotSeriesData
            {
                Low = SelfIns[0],
                Q1 = SelfIns[1],
                Median = SelfIns[2],
                Q3 = SelfIns[3],
                High = SelfIns[4],
                Color = "#5D63D3"
            };
        }
    }
