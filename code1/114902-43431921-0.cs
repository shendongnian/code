    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Traingames.NetElements;
    //using System.Windows.Forms;
    using System.Drawing;
    namespace ConsoleTools.NET
    {
    class Program
    {
        static ConsoleFramework c = new ConsoleFramework();
        static public Point MousePos;
        static Button One = new Button();
        static Pixel Mouse = new Pixel();
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.White;
            // t.Draw(10, 40, ConsoleColor.Gray);
            One.Set(0, 10, "░░1░░", ConsoleColor.Gray);
            GUI.Add(One);
            GUI.CalculateOnStart();
            for (;;)
            {
                MousePos = new Point(System.Windows.Forms.Control.MousePosition.X / (Console.LargestWindowWidth / 24), System.Windows.Forms.Control.MousePosition.Y / (Console.LargestWindowHeight / 7));
                if (One.Pressed(MousePos))
                {
                    Console.Write("1");
                }
                //   Console.Clear();
            }
        }
    }
    }
    namespace Traingames.NetElements
    {
        public class ConsoleFramework
        {
        public char[] chars = { '█', '▓', '▒', '░' };
        Point MousePos()
        {
            return new Point((System.Windows.Forms.Control.MousePosition.X / (Console.LargestWindowWidth / 24)) - 100, System.Windows.Forms.Control.MousePosition.Y / (Console.LargestWindowHeight / 7));
        }
        public void SetPixel(int x, int Y, ConsoleColor color)
        {
            int y = (int)Math.Floor(Y / 1.5f);
            for (int i = 0; i < y; i++)
            {
                Console.WriteLine("");
            }
            for (int i = 0; i < x - 1; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = color;
            Console.Write(" ");
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
    public class Pixel : GUI
    {
        public void Set(int X, int Y, string text)
        {
            ConsoleColor backColor = ConsoleColor.Black;
            BackColor = backColor;
            int yyyyyy = (int)Math.Floor(Y / 1.5f);
            Text = text;
            y = Y;
            x = X;
        }
    }
    public class GUI
    {
        public int x, y;
        public static GUI[,] GraphicalUserInterfaces = new GUI[1000, 1000];
        public ConsoleColor BackColor;
        public string Text;
        public void Draw()
        {
            int X = x;
            int Y = y;
            ConsoleColor backColor = BackColor;
            string text = Text;
            for (int i = 0; i < y; i++)
            {
                Console.WriteLine("");
            }
            for (int i = 0; i < x - 1; i++)
            {
                Console.Write(" ");
            }
            Console.BackgroundColor = BackColor;
            Console.Write("[" + text + "]");
            Console.BackgroundColor = ConsoleColor.Black;
            Point M = ConsoleTools.NET.Program.MousePos;
            // return M.X >= xx && M.X <= (xx + Text.Length + 1) && M.Y >= yy && M.Y <= yy + 2 && Control.MouseButtons == MouseButtons.Left;
        }
        static GUI Last;
        public static void Add(GUI gui)
        {
            GraphicalUserInterfaces[gui.x, gui.y] = gui;
        }
        public static void CalculateOnStart()
        {
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    if (GraphicalUserInterfaces[x, y] != null)
                    {
                        if (Last != null && y < Last.y)
                        {
                            GraphicalUserInterfaces[x, y].x = Last.x - GraphicalUserInterfaces[x, y].x;
                            GraphicalUserInterfaces[x, y].y = Last.y - GraphicalUserInterfaces[x, y].y;
                        }
                        GraphicalUserInterfaces[x, y].Draw();
                        GraphicalUserInterfaces[x, y].x = x;
                        GraphicalUserInterfaces[x, y].y = y;
                        Last = GraphicalUserInterfaces[x, y];
                    }
                }
            }
        }
    }
    public class Button : GUI
    {
        public bool Over(Point M)
        {
            int yy = ((y * 2) - y / 3) + 2;
            int xx = (x / (Console.LargestWindowWidth / 24)) + Text.Length;
            if (M.X >= xx && M.X <= (xx + Text.Length + 1) && M.Y >= yy && M.Y <= yy + 2)
                Console.BackgroundColor = ConsoleColor.DarkBlue;
            return M.X >= xx && M.X <= (xx + Text.Length + 1) && M.Y >= yy && M.Y <= yy + 2;
        }
        public bool Pressed(Point M)
        {
            int yy = ((y * 2) - y / 3) + 1;
            int xx = (x / (Console.LargestWindowWidth / 24));
            return M.X >= xx && M.X <= (xx + Text.Length * 1.5f) && M.Y >= yy && M.Y <= yy + 2 && System.Windows.Forms.Control.MouseButtons == System.Windows.Forms.MouseButtons.Left;
        }
        public void CalculateClick(Point M)
        {
            if (Pressed(M))
            {
                Console.Clear();
                Draw();
            }
        }
        public void Set(int X, int Y, string text, ConsoleColor backColor)
        {
            BackColor = backColor;
            int yyyyyy = (int)Math.Floor(Y / 1.5f);
            Text = text;
            y = Y;
            x = X;
            int xx = (x / (Console.LargestWindowWidth / 24)) + Text.Length;
        }
    }
    }
