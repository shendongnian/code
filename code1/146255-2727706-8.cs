    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Threading;
    using AForge;
    using AForge.Imaging;
    using AForge.Imaging.Filters;
    using AForge.Imaging.Textures;
    using AForge.Math.Geometry;
    
    namespace CDIO.Library
    {
        public class Polygon
        {
            List<IntPoint> hull;
            public Polygon(List<IntPoint> hull)
            {
                this.hull = hull;
            }
    
            public bool inPoly(int x, int y)
            {
                int i, j = hull.Count - 1;
                bool oddNodes = false;
    
                for (i = 0; i < hull.Count; i++)
                {
                    if (hull[i].Y < y && hull[j].Y >= y
                    || hull[j].Y < y && hull[i].Y >= y)
                    {
                        try
                        {
                            if (hull[i].X + (y - hull[i].X) / (hull[j].X - hull[i].X) * (hull[j].X - hull[i].X) < x)
                            {
                                oddNodes = !oddNodes;
                            }
                        }
                        catch (DivideByZeroException e)
                        {
                            if (0 < x)
                            {
                                oddNodes = !oddNodes;
                            }
                        }
                    }
                    j = i;
                }
                return oddNodes;
            }
    
            public Rectangle getRectangle()
            {
                int x = -1, y = -1, width = -1, height = -1;
                foreach (IntPoint item in hull)
                {
                    if (item.X < x || x == -1)
                        x = item.X;
                    if (item.Y < y || y == -1)
                        y = item.Y;
    
    
                    if (item.X > width || width == -1)
                        width = item.X;
                    if (item.Y > height || height == -1)
                        height = item.Y;
    
                    
                }
                return new Rectangle(x, y, width-x, height-y);
            }
            public Bitmap drawRectangle(Bitmap image)
            {
                Rectangle rect = getRectangle();
    
                Bitmap clonimage = (Bitmap)image.Clone();
                BitmapData data = clonimage.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
                Drawing.FillRectangle (data, rect, getRandomColor());
                clonimage.UnlockBits(data);
                return clonimage;
            }
    
            public Point[] getMap()
            {
                List<Point> points = new List<Point>();
                Rectangle rect = getRectangle();
                for (int x = rect.X; x <= rect.X + rect.Width; x++)
                {
                    for (int y = rect.Y; y <= rect.Y + rect.Height; y++)
                    {
                        if (inPoly(x, y))
                            points.Add(new Point(x, y));
                    }
                }
                return points.ToArray();
            }
    
            public float calculateArea()
            {
                List<IntPoint> list = new List<IntPoint>();
                list.AddRange(hull);
                list.Add(hull[0]);
    
                float area = 0.0f;
                for (int i = 0; i < hull.Count; i++)
                {
                    area += list[i].X * list[i + 1].Y - list[i].Y * list[i + 1].X;
                }
                area = area / 2;
                if (area < 0)
                    area = area * -1;
                return area;
            }
    
            public Bitmap draw(Bitmap image)
            {
                Bitmap clonimage = (Bitmap)image.Clone();
                BitmapData data = clonimage.LockBits(new Rectangle(0, 0, image.Width, image.Height), ImageLockMode.ReadWrite, image.PixelFormat);
                Drawing.Polygon(data, hull, Color.Red);
                clonimage.UnlockBits(data);
                return clonimage;
            }
    
            static Random random = new Random();
            int Color1, Color2, Color3;
            public Color getRandomColor()
            {
                Color1 = random.Next(0, 255);
                Color2 = random.Next(0, 255);
                Color3 = random.Next(0, 255);
                Color color = Color.FromArgb(Color1, Color2, Color3);
                Console.WriteLine("R: " + Color1 + " G: " + Color2 + " B: " + Color3 + " = " + color.Name);
                return color;
            }
        }
    }
