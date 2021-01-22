    public class ClassBlock
    {
        public int[] p;
        public int Sum
        {
            get { int s = 0;  Array.ForEach(p, delegate (int i) { s += i; }); return s; }
        }
    }
