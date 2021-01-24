    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;
    
    namespace WindowsFormsApp1
    {
        public partial class Form1 : Form
        {
            Collection<List<Point>> test = new Collection<List<Point>>();
            List<Point> seznamTock = new List<Point>();
    
            Pen barva_tock = new Pen(Color.Blue);
            Pen barva_kon_lupine = new Pen(Color.Black);
            Pen barva_tock_kon_lupine = new Pen(Color.Yellow);
    
            public Form1()
            {
                InitializeComponent();
    
                test.Add(seznamTock);
            }
    
            private List<Point> konveksnaLupina(List<Point> tocka)
            {
                List<Point> hull = new List<Point>();
                Point vPointOnHull = tocka.Where(p => p.X == tocka.Min(min =>
                min.X)).First();
    
                Point vEndpoint;
                do
                {
                    hull.Add(vPointOnHull);
                    vEndpoint = tocka[0];
    
                    for (int i = 1; i < tocka.Count; i++)
                    {
                        if ((vPointOnHull == vEndpoint)
                            || (Orientacija(vPointOnHull, vEndpoint, tocka[i]) ==
                         -1))
                        {
                            vEndpoint = tocka[i];
                        }
                    }
    
                    vPointOnHull = vEndpoint;
    
                }
                while (vEndpoint != hull[0]);
    
                return hull;
            }
    
            private static int Orientacija(Point p1, Point p2, Point p)
            {
                // Determinanta
                int Orin = (p2.X - p1.X) * (p.Y - p1.Y) - (p.X - p1.X) * (p2.Y - p1.Y);
    
                return (Orin == 0) ? Orin : ((Orin > 0) ? -1 : 1);
    
                //if (Orin > 0)
                //{
                //    return -1; //orientacija v levo
                //}
                //if (Orin < 0)
                //{
                //    return 1; //orientacija v desno
                //}
    
                //return 0; //neutralna orientacija
            }
    
            private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
            {
                Point zacasna = new Point();
                zacasna.X = e.X;
                zacasna.Y = e.Y;
                seznamTock.Add(zacasna);
    
                //pictureBox1.Image = Image.FromFile(file);
                using (var g = Graphics.FromImage(pictureBox1.Image))
                {
                    for (int i = 0; i < seznamTock.Count; i++) { g.DrawEllipse(barva_tock, seznamTock[i].X, seznamTock[i].Y, 5, 5); }
    
                    pictureBox1.Refresh();
                }
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                //if (seznamTock.Count < 3)
                //{
                //    MessageBox.Show("Premalo tock!");
                //    return;
                //}
    
                List<Point> hull = new List<Point>();
                hull = konveksnaLupina(seznamTock);
                //pictureBox1.Image = Image.FromFile(file);
    
                using (var g = Graphics.FromImage(pictureBox1.Image))
                {
    
                    for (int j = 0; j < seznamTock.Count; j++)
                    {
                        g.DrawEllipse(barva_tock, seznamTock[j].X, seznamTock[j].Y,
                        5, 5);
                    }
                    for (int j = 0; j < hull.Count; j++)
                    {
                        Point tocka1 = new Point(hull[j].X, hull[j].Y);
                        Point tocka2 = new Point(hull[(j + 1) % hull.Count].X,
                       hull[(j + 1) % hull.Count].Y);
                        g.DrawLine(barva_kon_lupine, tocka1, tocka2);
                    }
                    for (int j = 0; j < hull.Count; j++)
                    {
                        g.DrawEllipse(barva_tock_kon_lupine, hull[j].X, hull[j].Y, 5, 5);
                    }
    
                    pictureBox1.Refresh();
    
                    test.Add(seznamTock);
                    seznamTock = new List<Point>();
                }
            }
        }
    }
