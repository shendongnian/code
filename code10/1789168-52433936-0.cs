    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    namespace so_pointsfromcurve
    {
        class Program
        {
            static void Main(string[] args)
            {
                /* some test data */
                var pointss = new Point[]
                {
                    new Point(5,20),
                    new Point(17,63),
                    new Point(2,9)
                };
                /* instead of to the picture box, draw to a path */
                using (var path = new GraphicsPath())
                {
                    path.AddCurve(pointss, 1.0F);
                    /* use a unit matrix to get points per pixel */
                    using (var mx = new Matrix(1, 0, 0, 1, 0, 0))
                    {                    
                        path.Flatten(mx, 0.1f);
                    }
                    /* store points in a list */
                    var list_of_points = new List<PointF>(path.PathPoints);
                    /* show them */
                    int i = 0;
                    foreach(var point in list_of_points)
                    {
                        Debug.WriteLine($"Point #{ ++i }: X={ point.X }, Y={point.Y}");
                    }
                }
            
            }
        }
    }
