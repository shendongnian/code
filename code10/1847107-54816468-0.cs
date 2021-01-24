    public class Domino {
        public Domino(int a, int b)
        {
            A = a;
            B = b;
        }
        public int A { get; set; }
        public int B { get; set; }
        
        public Domino Flipped()
        {
            return new Domino(B, A);
        }
        public override string ToString()
        {
            return $"[{A}/{B}]";
        }
    }
