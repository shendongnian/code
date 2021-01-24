    public partial class Form1 : Form
    {
       
        public Form1()
        {
            InitializeComponent();
        }
        //I moved the initialization of dt to the declaration
        public double dt = 0.01;
        //t will be initialized to 0 by default
        public double t;
        public double[] RawAcX = new double[500];
        //this method is never called so I commented it out
        //public void init()
        //{
        //    dt = 0.01;
        //    t = 0;
        //    RawAcX = null;
        //}
        private void sensor_input()
        {
            for (int i = 0; i < 500; i++)
            {
                RawAcX[i] = Math.Sin(t);
                //this seems unnecessary since RawAcs is declared as double
                //RawAcX[i] = Convert.ToDouble(RawAcX[i]);
                t += dt;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            sensor_input();
            graph_acX.Series.Clear();
            graph_filter_acX.Series.Clear();
            Series AcX = graph_acX.Series.Add("AcX");
            Series F_AcX = graph_filter_acX.Series.Add("F_AcX");
            AcX.ChartType = SeriesChartType.Line;
            for (int k = 0; k < 500; k++)
            {
                AcX.Points.AddXY(k * 0.1, RawAcX[k]);
            }
            //I get a sine wave on graph_filter and nothing in graph_filter_acX
        }
    }
