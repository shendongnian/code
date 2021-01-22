    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Random rand = new Random(1325165);
            int maxValue = 100;
            int numberOfBuckets = 100;
            List<double> values = new List<double>();
            for (int i = 0; i < 10000000; i++)
            {
                double value = rand.NextDouble() * (maxValue+1);               
                values.Add(value);
            }
            int[] bins = values.Bucketize(numberOfBuckets);
            PointPairList points = new PointPairList();
            for (int i = 0; i < numberOfBuckets; i++)
            {
                points.Add(i, bins[i]);
            }
            zedGraphControl1.GraphPane.AddBar("Random Points", points,Color.Black);
            zedGraphControl1.GraphPane.YAxis.Title.Text = "Count";
            zedGraphControl1.GraphPane.XAxis.Title.Text = "Value";
   
            zedGraphControl1.AxisChange();
            zedGraphControl1.Refresh();
        }
    }
    public static class Extension
    {
        public static int[] Bucketize(this IEnumerable<double> source, int totalBuckets)
        {
            var min = source.Min();
            var max = source.Max();
            var buckets = new int[totalBuckets];
            var bucketSize = (max - min) / totalBuckets;
            foreach (var value in source)
            {
                int bucketIndex = 0;
                if (bucketSize > 0.0)
                {
                    bucketIndex = (int)((value - min) / bucketSize);
                    if (bucketIndex == totalBuckets)
                    {
                        bucketIndex--;
                    }
                }
                buckets[bucketIndex]++;
            }
            return buckets;
        }
    }
