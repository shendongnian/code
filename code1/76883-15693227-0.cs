    using System;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    
    namespace Soundfingerprinting.Audio.Services
    {
        public static class AudioVisualizationService
        {
            public class WaveVisualizationConfiguration
            {
                public Nullable<Color> AreaColor { get; set; }
                public Nullable<Color> EdgeColor { get; set; }
                public int EdgeSize { get; set; }
                public Nullable<Rectangle> Bounds { get; set; }
                public double Overlap { get; set; }
                public int Step { get; set; }
            }
    
            public static void DrawWave(float[] data, Bitmap bitmap, WaveVisualizationConfiguration config = null)
            {
                Color areaColor = Color.FromArgb(0x7F87CEFA);// Color.LightSkyBlue; semi transparent
                Color edgeColor = Color.DarkSlateBlue;
                int edgeSize = 2;
                int step = 2;
                double overlap = 0.10f; // would better use a windowing function
                Rectangle bounds = Rectangle.FromLTRB(0, 0, bitmap.Width, bitmap.Height);
    
                if (config != null)
                {
                    edgeSize = config.EdgeSize;
                    if (config.AreaColor.HasValue)
                        areaColor = config.AreaColor.GetValueOrDefault();
                    if (config.EdgeColor.HasValue)
                        edgeColor = config.EdgeColor.GetValueOrDefault();
                    if (config.Bounds.HasValue)
                        bounds = config.Bounds.GetValueOrDefault();
                        
                    step = Math.Max(1, config.Step);
                    overlap = config.Overlap;
                }
    
                float width = bounds.Width;
                float height = bounds.Height;
                
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    Pen edgePen = new Pen(edgeColor);
                    edgePen.LineJoin = LineJoin.Round;
                    edgePen.Width = edgeSize;
                    Brush areaBrush = new SolidBrush(areaColor);
    
                    float size = data.Length;
                    PointF[] topCurve = new PointF[(int)width / step];
                    PointF[] bottomCurve = new PointF[(int)width / step];
                    int idx = 0;
                    for (float iPixel = 0; iPixel < width; iPixel += step)
                    {
                        // determine start and end points within WAV
                        int start = (int)(iPixel * (size / width));
                        int end = (int)((iPixel + step) * (size / width));
                        int window = end - start;
                        start -= (int)(overlap * window);
                        end += (int)(overlap * window);
                        if (start < 0)
                            start = 0;
                        if (end > data.Length)
                            end = data.Length;
    
                        float posAvg, negAvg;
                        averages(data, start, end, out posAvg, out negAvg);
    
                        float yMax = height - ((posAvg + 1) * .5f * height);
                        float yMin = height - ((negAvg + 1) * .5f * height);
                        float xPos = iPixel + bounds.Left;
                        if (idx >= topCurve.Length)
                            idx = topCurve.Length - 1;
                        topCurve[idx] = new PointF(xPos, yMax);
                        bottomCurve[bottomCurve.Length - idx - 1] = new PointF(xPos, yMin);
                        idx++;
                    }
    
                    PointF[] curve = new PointF[topCurve.Length * 2];
                    Array.Copy(topCurve, curve, topCurve.Length);
                    Array.Copy(bottomCurve, 0, curve, topCurve.Length, bottomCurve.Length);
                    g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    g.SmoothingMode = SmoothingMode.AntiAlias;
                    g.FillClosedCurve(areaBrush, curve, FillMode.Winding, 0.15f);
                    if (edgeSize > 0)
                        g.DrawClosedCurve(edgePen, curve, 0.15f, FillMode.Winding);
                }
    
            }
    
            private static void averages(float[] data, int startIndex, int endIndex, out float posAvg, out float negAvg)
            {
                posAvg = 0.0f;
                negAvg = 0.0f;
    
                int posCount = 0, negCount = 0;
    
                for (int i = startIndex; i < endIndex; i++)
                {
                    if (data[i] > 0)
                    {
                        posCount++;
                        posAvg += data[i];
                    }
                    else
                    {
                        negCount++;
                        negAvg += data[i];
                    }
                }
    
                if (posCount > 0)
                    posAvg /= posCount;
                if (negCount > 0)
                    negAvg /= negCount;
            }
        }
    }
