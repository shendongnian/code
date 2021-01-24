    public class Vsquare
    {
        public int length;
        public int width;
        public Vsquare(int w, int l)
        {
            l = length;
            w = width;
        }
        public override string ToString()
        {
           return $"{l},{w}";
        }
    }
(As noted in the comments for the question, the constructor's assignment statements are backward, but I haven't fixed that in this excerpt.)
