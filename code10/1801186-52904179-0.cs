    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace RandomizeAlgo {
    
        class Program {
            public static void Main(string[] args) {
                int people = 0;
                double factor = 0.0;
                getInputs(ref people, ref factor);
                Random r = new Random();
                List<double> randoms = new List<double>();
                double total = factor + people;
                double divisor = Math.Round(total / people, 2);
                double counter = 0.0;
                if (people % 2 == 1) {
                    randoms.Add(Math.Round(Math.Min(Math.Min(r.NextDouble() + 0.01, 0.99) * 10 / people, divisor), 2));
                    total -= randoms[0];
                    divisor = Math.Round(total / (people - 1), 2);
                    counter += randoms[0];
                } for (int i = randoms.Count; i != people; i += 2) {
                    if (i == people - 2) {
                        double finals = Math.Round(Math.Min(r.NextDouble() + 0.01, 0.99) * divisor, 2);
                        randoms.Add(finals);
                        randoms.Add(Math.Round((people + factor) - (counter + finals), 2));
                    } randoms.AddRange(getRandomPair(divisor, r, ref counter));
                } counter = 0.0;
                for (int i = 0; i != people; i++) {
                    counter += randoms[i];
                    Console.WriteLine("+ " + randoms[i].ToString() + " = " + counter.ToString());
                } Console.ReadLine();
            }
            public static void getInputs(ref int people, ref double factor) {
                while (true) {
                    Console.Clear();
                    Console.Write("Integer: ");
                    try { people = Convert.ToInt32(Console.ReadLine()); break; }
                    catch { Console.WriteLine("ERROR: Must be an integer."); Console.ReadLine(); }
                } while (true) {
                    Console.Clear();
                    Console.Write("Double: ");
                    try { factor = Convert.ToDouble(Console.ReadLine()); break; }
                    catch { Console.WriteLine("ERROR: Must be an double."); Console.ReadLine(); }
                }
            }
            public static double[] getRandomPair(double divisor, Random r, ref double counter) {
                double[] parts = { Math.Round(Math.Min(r.NextDouble() + 0.01, 0.99) * divisor, 2), 0 };
                parts[1] = (divisor * 2) - parts[0];
                counter = counter + parts[0] + parts[1];
                return parts;
            }
        }
    }
