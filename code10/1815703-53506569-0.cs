    public partial class Form1 : Form
        {
            private int _pointsCount;
    
            public Form1()
            {
                InitializeComponent();
            }
            
            private void Draw()
            {
                _pointsCount = 300000;
                var range = Enumerable.Range(0, _pointsCount);
                Series series = new Series();
    
                foreach (var i in range)
                {
                    series.Points.Add(new DataPoint(0, i));
                }
    
                chart1.PostPaint += OnDrawingFinished;
                chart1.Series.Add(series);
            }
    
            private void OnDrawingFinished(object sender, ChartPaintEventArgs e)
            {
                var chart = (Chart)sender;
                var points = chart.Series.SelectMany(x => x.Points).Count();
    
                if (points < _pointsCount) return;
    
                MessageBox.Show("Done!");
                chart1.PostPaint -= OnDrawingFinished;
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                Draw();
            }
        }
