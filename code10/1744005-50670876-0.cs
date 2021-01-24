    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.IO.Ports;
    using System.Threading;
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
        public string data;
        private List<Point> points = new List<Point>();  
        public string[] coordinates;
        private Pen pen;
        public Bitmap obrazek;
        public int i = 0;
    
        public Form1()
        {
            InitializeComponent();
            obrazek = new Bitmap(1000, 1000); 
            using (Graphics g = Graphics.FromImage(obrazek))
            g.Clear(Color.White); 
            SerialPort serialPort1 = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            serialPort1.Open();
            serialPort1.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
            DoubleBuffered = true;
            pen = new Pen(Color.Black, 3);
            points = new List<Point>();
 
        }
       
        public void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            
            SerialPort TempSerialPort = (SerialPort)sender;
            //Console.WriteLine("data_recived");
            data = TempSerialPort.ReadLine();
            Console.WriteLine(data);
            pointlist_reciver();
            //this.Invalidate();
            pictureBox2.Invalidate();
        }
       
        public void pointlist_reciver()
        {
            
            int x1;
            int y1;
            string[] coordinates = data.Split(',');
            string x = coordinates[0];
            string y = coordinates[1];
            Int32.TryParse(x, out x1);
            Int32.TryParse(y, out y1);
            points.Add(new Point(x1, y1));
            Console.WriteLine(points.Count.ToString());
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawImage(obrazek, 0, 0);
            if (points.Count >= 2)
            {
               
                List<Point> points2 = points.GetRange(0, 2);
                using (Graphics g = Graphics.FromImage(obrazek)) 
                g.DrawLines(pen, points2.ToArray());
                points.Clear();
                
            }
        }
     }
    }
