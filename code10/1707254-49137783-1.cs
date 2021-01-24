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
    /// <summary>
    /// Contains utility methods to retrieve plot data.
    /// </summary>
    public static class BloxPlotHelper
    {
        private const string CaptivePlotColor = "#C111A0";
        private const string ParentPlotColor = "#FFB81C";
        /// <summary>
        /// Returns plot data.
        /// </summary>
        /// <param name="evaResultsGraphData">Contains raw data.</param>
        /// <returns>Plot data.</returns>
        public static Series<BloxPlotSeriesData> GenerateBoxPlotChartSeries(GraphData evaResultsGraphData)
        {
            BloxPlotSeriesData captiveViewSeriesData = GetCaptivePlotData(evaResultsGraphData);
            BloxPlotSeriesData parentViewSeriesData = GetParentData(evaResultsGraphData);
            var Result = new Series<BloxPlotSeriesData>
            {
                Data = new List<BloxPlotSeriesData> { captiveViewSeriesData, parentViewSeriesData }
            };
            return AddMoreData(evaResultsGraphData, Result);
        }
        /// <summary>
        /// Adds more data if the first argument can provide it.
        /// </summary>
        /// <param name="evaResultsGraphData"></param>
        /// <param name="Result"></param>
        /// <returns></returns>
        private static Series<BloxPlotSeriesData> AddMoreData(GraphData evaResultsGraphData, Series<BloxPlotSeriesData> Result)
        {
            var MoreData = evaResultsGraphData.ReturnMoreData();
            if (MoreData != null)
            {
                Result.Data.Add(MoreData);
            }
            return Result;
        }
        private static BloxPlotSeriesData GetParentData(GraphData evaResultsGraphData)
        {
            return new BloxPlotSeriesData
            {
                Low = evaResultsGraphData.ParentView[0],
                Q1 = evaResultsGraphData.ParentView[1],
                Median = evaResultsGraphData.ParentView[2],
                Q3 = evaResultsGraphData.ParentView[3],
                High = evaResultsGraphData.ParentView[4],
                Color = ParentPlotColor
            };
        }
        private static BloxPlotSeriesData GetCaptivePlotData(GraphData evaResultsGraphData)
        {
            return new BloxPlotSeriesData
            {
                Low = evaResultsGraphData.CaptiveView[0],
                Q1 = evaResultsGraphData.CaptiveView[1],
                Median = evaResultsGraphData.CaptiveView[2],
                Q3 = evaResultsGraphData.CaptiveView[3],
                High = evaResultsGraphData.CaptiveView[4],
                Color = CaptivePlotColor
            };
        }
    }
