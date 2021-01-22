    public partial class Form1 : Form
    {
        DateTime earliestDate;
        public Form1()
        {
            earliestDate = DateTime.Now;
            earliestDate = earliestDate.AddDays(-1);
            InitializeComponent();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            while (earliestDate < DateTime.Today)
            {
                float currPosX = 0;
                currPosX = currPosX + 5;
                e.Graphics.DrawLine(Pens.Black, currPosX, 0, currPosX + 5, 10);
                earliestDate = earliestDate.AddDays(1);
            } 
        }
    }
