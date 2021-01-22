    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Drawing;
    
    namespace Battleship.ShuggyCoUk
    {
        public class Rand
        {
            Random r;
    
            public Rand()
            {
                var rand = System.Security.Cryptography.RandomNumberGenerator.Create();
                byte[] b = new byte[4];
                rand.GetBytes(b);
                r = new Random(BitConverter.ToInt32(b, 0));
            }
    
            public int Next(int maxValue)
            {
                return r.Next(maxValue);
            }
    
            public double NextDouble(double maxValue)
            {
                return r.NextDouble() * maxValue;
            }
    
            public T Pick<T>(IEnumerable<T> things)
            {
                return things.ElementAt(Next(things.Count()));
            }
    
            public T PickBias<T>(Func<T, double> bias, IEnumerable<T> things)
            {
                double d = NextDouble(things.Sum(x => bias(x)));
                foreach (var x in things)
                {
                    if (d < bias(x))
                        return x;
                    d -= bias(x);                
                }
                throw new InvalidOperationException("fell off the end!");
            }
        }
    }
