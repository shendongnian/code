    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                new RipleCount52(10000);
            }
        }
        public class RipleCount52
        {
            //places are a number from 0 t0 51 indicating each of the 52 charaters
            //the least significant place is index 0
            //when printing character the order has to be reversed so most significant place gets printed first.
            public List<int> places = new List<int>();
            public RipleCount52(int maxNumber)
            {
                int count = 0;
                places.Add(count);
                for (int i = 0; i < maxNumber; i++)
                {
                    string output = string.Join("",places.Reverse<int>().Select(x => (x < 26) ? (char)((int)'a' + x) : (char)((int)'A' + x - 26)));
                    Console.WriteLine(output);
                    places[0] += 1;
                    //riple after all 52 letter are printed
                    if (count++ == 51)
                    {
                        Ripple();
                        count = 0;
                    }
                }
            }
            private void Ripple()
            {
                //loop until no ripple is required
                for (int i = 0; i < places.Count(); i++)
                {
                    if (places[i] == 52)
                    {
                        //all places rippled to new place needs to be added
                        if (i == places.Count - 1)
                        {
                            places[i] = 0;
                            places.Insert(0, 0);
                            break;
                        }
                    }
                    else
                    {
                        //no more ripples are required so exit
                        places[i] += 1;
                        break;
                    }
                    places[i] = 0;
                }
            }
        }
    }
