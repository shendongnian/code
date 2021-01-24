    public abstract class GraphData
    {
        [JsonMinify]
        public List<double> CaptiveView { get; set; }
        [JsonMinify]
        public List<double> ParentView { get; set; }
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
                low = SelfIns[0],
                q1 = SelfIns[1],
                median = SelfIns[2],
                q3 = SelfIns[3],
                high = SelfIns[4],
                Color = "#5D63D3"
            };
        }
    }
    class Helper
    {
        private Series<BloxPlotSeriesData> GenerateBoxPlotChartSeries(GraphData evaResultsGraphData)
        {
            //CaptiveView
            var captiveViewSeriesData = new BloxPlotSeriesData
            {
                low = evaResultsGraphData.CaptiveView[0],
                q1 = evaResultsGraphData.CaptiveView[1],
                median = evaResultsGraphData.CaptiveView[2],
                q3 = evaResultsGraphData.CaptiveView[3],
                high = evaResultsGraphData.CaptiveView[4],
                Color = "#C111A0"
            };
            //ParentView
            var parentViewSeriesData = new BloxPlotSeriesData
            {
                low = evaResultsGraphData.ParentView[0],
                q1 = evaResultsGraphData.ParentView[1],
                median = evaResultsGraphData.ParentView[2],
                q3 = evaResultsGraphData.ParentView[3],
                high = evaResultsGraphData.ParentView[4],
                Color = "#FFB81C"
            };
            var Result = new Series<BloxPlotSeriesData>
            {
                data = new List<BloxPlotSeriesData> { captiveViewSeriesData, parentViewSeriesData }
            };
            var MoreData = evaResultsGraphData.ReturnMoreData();
            if (MoreData != null)
            {
                Result.data.Add(MoreData);
            }
            return Result;
        }
