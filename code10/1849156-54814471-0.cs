    public class Domino
    {
        public int A { get; set; }
        public int B { get; set; }
        public Domino(int a, int b)
        {
            A = a;
            B = b;
        }
        public Domino Flipped()
        {
            return new Domino(B, A);
        }
        public override string ToString()
        {
            return $"[{A}/{B}]";
        }
    }   
    public class Program
    {
        private static void ListChains(List<Domino> chain, List<Domino> list)
        {
            for (int i = 0; i < list.Count; ++i)
            {
                Domino dom = list[i];
                if (CanAppend(dom, chain))
                {
                    chain.Add(dom);
                    Console.WriteLine(string.Join("-", chain));
                    Domino saved = list[i];
                    list.RemoveAt(i);
                    ListChains(chain, list);
                    list.Insert(i, saved);
                    chain.RemoveAt(chain.Count - 1);
                }
                dom = dom.Flipped();
                if (CanAppend(dom, chain))
                {
                    chain.Add(dom);
                    Console.WriteLine(string.Join("-", chain));
                    Domino saved = list[i];
                    list.RemoveAt(i);
                    ListChains(chain, list);
                    list.Insert(i, saved);
                    chain.RemoveAt(chain.Count - 1);
                }
            }
        }
        private static bool CanAppend(Domino domino, List<Domino> chain)
        {
            if (chain == null || !chain.Any()) return true;
            return chain.Last().B == domino?.A;
        }
        
        private static void Main()
        {
            var dominos = new List<Domino>
            {
                new Domino(1, 4),
                new Domino(3, 4),
                new Domino(1, 6),
                new Domino(5, 6)
            };
            ListChains(new List<Domino>(), dominos);
            Console.ReadKey();
        }
    }
