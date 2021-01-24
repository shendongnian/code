    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Paint += onPaint;
        }
    
        List<LogModel> logModels;
    
        private void onPaint(object sender, PaintEventArgs e)
        {
            try
            {
                DrawXYBse(e.Graphics);
    
                if (logModels != null)
                    SetDots(e.Graphics);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
    
        }
    
        private void DrawXYBse(Graphics g)
        { }
    
        public void SetDots(Graphics g)
        {
            g.DrawLine(Pens.Orange, 80f, 80f, 80.1f, 80.1f);
            foreach (LogModel logModel in logModels)
            {
                g.DrawLine(Pens.Orange, logModel.DX + 80f, logModel.DY + 80f, logModel.DX + 90.1f, logModel.DY + 90.1f);
            }
        }
    
        public void CallOnPaint(List<LogModel> logModels)
        {
            this.logModels = logModels;
            //call onPaint()
            this.Refresh();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            CallOnPaint(new List<LogModel>()
            {
                new LogModel(){DX = 20, DY =20},
                new LogModel(){DX = 40, DY =30},
                new LogModel(){DX = 60, DY =40},
                new LogModel(){DX = 80, DY =50},
                new LogModel(){DX = 90, DY =60},
                new LogModel(){DX = 100, DY =70},
            });
        }
    }
    public class LogModel
    {
        public float DX { get; set; }
        public float DY { get; set; }
    
    }
