     int i;
       public Form1(int i)
            {
                InitializeComponent();
                this.i = i;
            }
    private void Form1_Load(object sender, EventArgs e)
            {
                using (Bitmap bmp = new Bitmap(this.Width, this.Height))
                {
                    this.DrawToBitmap(bmp, new Rectangle(Point.Empty, bmp.Size));
                   bmp.Save(@"C:\Users\User\Desktop\sample" + i+".png", ImageFormat.Png);
                }
            }
     private void Form1_Paint(object sender, PaintEventArgs e)
            {
                int x1, y1, x2, y2;
                Random losowa1 = new Random();
                x1 = losowa1.Next(0, 200);
                Random losowa2 = new Random();
                y1 = losowa2.Next(0, 480);
                Random losowa3 = new Random();
                x2 = losowa1.Next(300, 500);
                Random losowa4 = new Random();
                y2 = losowa2.Next(0, 480);
                e.Graphics.FillRectangle(Brushes.Black, x1, y1, 100, 100);
                e.Graphics.FillEllipse(Brushes.Black, x2, y2, 100, 100);
                System.Threading.Thread.Sleep(2000);
                this.Close();
            }
  
  
       private void button1_Click(object sender, EventArgs e)
            {
                for (int i=0;i<3;i++) {
                    Form1 form1 = new Form1(i);
                    form1.ShowDialog();
                    
                }
            }
