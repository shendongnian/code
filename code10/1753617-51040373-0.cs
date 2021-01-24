    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    namespace ConsoleApplication1
    {
        enum State
        {
            UNKNOWN,
            POSITIVE,
            NEGATIVE
        }
        class Program
        {
            static void Main(string[] args)
            {
                string input = "10,5; 11,6; 12,7; 11,8; 10,9; 10,15; 11,16; 12,17; 11,18; 10,19";
                string[] splitSemicolon = input.Split(new char[] { ';' });
                Point[] points = splitSemicolon.Select(x => x.Split(new char[] { ',' })).Select(x => new Point(int.Parse(x.FirstOrDefault()), int.Parse(x.LastOrDefault()))).ToArray();            
                
                State state = State.UNKNOWN;
                List<Cycle> cycles = new List<Cycle>();
                Cycle newCycle = null;
                for (int i = 1; i < points.Length; i++)
                {
                    double slope = 0;
                    if (points[i].X == points[i - 1].X)
                    {
                        slope = points[i].Y - points[i - 1].Y;
                    }
                    else
                    {
                        slope = (points[i].Y - points[i - 1].Y) / (points[i].X - points[i - 1].X);
                    }
                    switch (state)
                    {
                        case State.UNKNOWN:
                            newCycle = new Cycle();
                            cycles.Add(newCycle);
                            if (slope < 0)
                            {
                                newCycle.negativeSlope = new List<Point> { points[0], points[1] };
                                state = State.NEGATIVE;
                            }
                            else
                            {
                                newCycle.positiveSlope = new List<Point> { points[0], points[1] };
                                state = State.POSITIVE;
                            }
                            break;
                        case State.POSITIVE :
                            if (slope > 0)
                            {
                                newCycle.positiveSlope.Add(points[i]);
                            }
                            else
                            {
                                newCycle = new Cycle();
                                cycles.Add(newCycle);
                                newCycle.negativeSlope = new List<Point>() { points[i] };
                                state = State.NEGATIVE;
                            }
                            break;
                        case State.NEGATIVE:
                            if (slope > 0)
                            {
                                newCycle.positiveSlope = new List<Point>() { points[i] };
                                state = State.POSITIVE;
                            }
                            else
                            {
                                newCycle.negativeSlope.Add(points[i]);
                            }
                            break;
                    }
                }
            }
        }
        public class Cycle
        {
            public List<Point> negativeSlope { get; set; }
            public List<Point> positiveSlope { get; set; }
        }
    }
