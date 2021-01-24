    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Drawing;
    namespace ConsoleApp2
    {
        class Program
        {
     
            static void Main()
            {
                Color color =  RGBScale.AverageColor(.5F);
            }
        }
        public class RGBScale
        {
            //each row is defined as follows
            //low range, high range,   Ra,      Ga,      Ba,      Rb,      Gb,      Bb,
            public static List<List<int>> table = new List<List<int>>() {
                new List<int>() {0, 0, 255, 255, 255, 255, 255, 255},
                new List<int>() {0, 1, 165, 242, 243, 125, 200, 255},
                new List<int>() {1, 25, 0, 255, 0, 63, 82, 0},
                new List<int>() {25, 50, 63, 82, 0, 255, 143, 31},
                new List<int>() {50, 75, 255, 143, 31, 255, 0, 0},
                new List<int>() {75, 100, 255, 0, 0, 255, 0,0}
            };
            public static Color AverageColor(float index)
            {
                int red = 255;
                int blue = 255;
                int green = 255;
                foreach (List<int> row in table)
                {
                    if (index < row[1])
                    {
                        double start = row[0];
                        double end = row[1];
                        double scale = (index - start) / (end - start); 
                        red = (int)Math.Round(scale * (row[5] - row[2]) + row[2]);
                        green = (int)Math.Round(scale * (row[6] - row[3]) + row[3]);
                        blue = (int)Math.Round(scale * (row[7] - row[4]) + row[4]);
                        break;
                    }
                }
                return Color.FromArgb(red, green, blue);
            }
        }
    }
