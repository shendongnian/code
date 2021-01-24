    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // Maximum/Minimum controls the length of the Axis
            chart1.ChartAreas[0].AxisX.Maximum = 30;
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            chart1.ChartAreas[0].AxisY.Maximum = 30;
            chart1.ChartAreas[0].AxisY.Minimum = 0;
            // Interval controls the interval between values on the chart
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisY.Interval = 1;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            chart1.ChartAreas[0].AxisX.Minimum = 0;
            for (int i = 0; i <= 24; i++)
            {
                chart1.Series[0].Points.AddXY(i, 1 + i);
            }
        }
    }
