    public class CustomPointRenderableSeries : CustomRenderableSeries
    {
        protected override void Draw(IRenderContext2D renderContext, IRenderPassData renderPassData)
        {
            base.Draw(renderContext, renderPassData);
    
            // Get the CustomPointRenderableSeries.PointMarker to draw at original points
            // Assumes you have declared one in XAML or code
            //
            // e.g. CustomPointRenderableSeries.PointMarker = new EllipsePointMarker();
            //
            var pointMarker = base.GetPointMarker();
            if (pointMarker != null)
            {
                // The resampled data for this render pass
                var dataPointSeries = renderPassData.PointSeries;
    
                var xCalc = renderPassData.XCoordinateCalculator;
                var yCalc = renderPassData.YCoordinateCalculator;
    
                // Begin a batched PointMarker draw operation
                pointMarker.BeginBatch(renderContext, pointMarker.Stroke, pointMarker.Fill);
    
                // Iterate over the data
                for (int i = 0; i < dataPointSeries.Count; i++)
                {
                    // Convert data to coords
                    double xCoord = xCalc.GetCoordinate(dataPointSeries.XValues[i]);
                    double yCoord = yCalc.GetCoordinate(dataPointSeries.YValues[i]);
                    int dataIndex = dataPointSeries.Indexes[i];
    
                    // Draw at current location
                    pointMarker.MoveTo(renderContext, xCoord, yCoord, dataIndex);
                }
    
                // End the batch
                // Note: To change point color, start a new batch
                pointMarker.EndBatch(renderContext);
            }
        }
    }
