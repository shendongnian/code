        public class Distances
        {
            public double Distance { get; set; }
            public Point3D FromPoint { get; set; }
            public Point3D ToPoint { get; set; }
            
            public Distances(Point3D from, Point3D to)
            {
                FromPoint = from;
                ToPoint = to;
                Distance = (to - from).Length;
            }
        }
        private void OP2()
        {
            List<Point3D> searchFrom = new List<Point3D>()
            {
            new Point3D(20,30,50),
            new Point3D(10,50,10),
            new Point3D(30,40,20),
            new Point3D(60,30,10)
            };
            List<Point3D> searchCloud = new List<Point3D>()
            {
            new Point3D(60,70,80),
            new Point3D(110,30,30),
            new Point3D(80,110,55),
            new Point3D(90,20,90)
            };
            List<Distances> resultDistances = new List<Distances>();
            foreach (Point3D p1 in searchFrom)
            {
                foreach (Point3D p2 in searchCloud)
                {
                    Distances d = new Distances(p1, p2);
                    resultDistances.Add(d);
                }
            }
            //The following is just for testing purposes, skip to var longestDistance
            List<Distances> distancesInOrder = resultDistances.OrderByDescending(i => i.Distance).ToList<Distances>();
            foreach (Distances d in distancesInOrder)
            {
                Debug.Print($"From Point ({d.FromPoint.X}, {d.FromPoint.Y}, {d.FromPoint.Z}) To Point ({d.ToPoint.X}, {d.ToPoint.Y}, {d.ToPoint.Z}) Distance = {d.Distance}");
            }
            var longestDistance = resultDistances.OrderByDescending(i => i.Distance).FirstOrDefault();
            //this gives you the longest distance and the two points
            MessageBox.Show($"First Point ({longestDistance.FromPoint.X}, {longestDistance.FromPoint.Y}, {longestDistance.FromPoint.Z}) Cloud Point ({longestDistance.ToPoint.X}, {longestDistance.ToPoint.Y}, {longestDistance.FromPoint.Z}) Distance = {longestDistance.Distance}");
        }
