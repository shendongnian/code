    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    class Baker
    {
        List<string> myList = new List<string>();
    
        public string Bake(string flavor)
        {
            for (int i = 0; i < 5; ++i)
            {
                myList.Add(flavor); // free to modify local data without synchronization
            }
            return string.Join("", myList);
        }
    }
    class Program
    {
        static string Icing(string layer)
        {
            return new string('~', layer.Length) + Environment.NewLine + layer + Environment.NewLine;
        }
    
        static void Main(string[] args)
        {
            Baker a = new Baker();
            Baker b = new Baker();
            Baker c = new Baker();
            Baker d = new Baker();
    
            string cake_a = null;
            string cake_b = null;
            string cake_c = null;
            string cake_d = null;
    
            Parallel.Invoke(
                () => { cake_a = a.Bake("*cherry*"); },
                () => { cake_b = b.Bake("*orange*"); },
                () => { cake_c = c.Bake("*banana*"); },
                () => { cake_d = d.Bake("*choco**"); }
                );
            string layer_cake = Icing(cake_a) + Icing(cake_b) + Icing(cake_c) + Icing(cake_d);
    
            Console.WriteLine(layer_cake);
        }
    }
