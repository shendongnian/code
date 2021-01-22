    using System;
    
    namespace Uni_19
    {
        class Timer
        {
            private int Seconds;
            private int Minutes;
            private int Hours;
            private int Days = 0;
    
            public int Sec
            {
                get { return Seconds; }
                set
                {
                    Seconds = value % 60;
                    Minutes += value / 60;
                }
            }
            public int Min
            {
                get { return Minutes; }
                set
                {
                    Minutes = value % 60;
                    Hour += (value / 60);
                }
            }
            public int Hour
            {
                get { return Hours; }
                set
                {
                    Hours = value % 24;
                    Days += value / 24;
                }
            }
            public int Day
            {
                get { return Days; }
                set { Days = Hour / 24; }
            }
            public int AddSec(int A)
            {
                Sec += A;
                return Sec;
            }
            public int AddMin(int B)
            {
                Min += B;
                return Min;
            }
            public int AddHour(int C)
            {
                Hour = Hour + (C % 24);
                return Hour;
            }
            public int AddDay(int D)
            {
                Day += D;
                return Day;
            }
            public void Read()
            {
                Console.WriteLine("Time Is: {0}", Hours + " : " + Minutes + " : " + Seconds);
                Console.Write("Time Added (in Seconds): ");
                AddSec(int.Parse(Console.ReadLine()));
                Console.Write("Time Added (in Minutes): ");
                AddMin(int.Parse(Console.ReadLine()));
                Console.Write("Time Added (in Houres): ");
                AddHour(int.Parse(Console.ReadLine()));
            }
            public void Write()
            {
                Console.WriteLine("New Time Is: {0}", Day + " : " + Hour + " : " + Min + " : " + Sec);
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                Timer S1 = new Timer();
                S1.Sec = 10;
                S1.Min = 25;
                S1.Hour = 23;
                S1.Read();
                S1.Write();
            }
        }
    }
