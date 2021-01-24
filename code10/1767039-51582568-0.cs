    public class Class1
    {
        public int x;
        public int y;
        public int z;
        public int myValue;
        public static bool IsNeighbour(Class1 c1, Class1 c2)
        {
            bool ret = ((Math.Abs(c1.x - c2.x) == 1) && c1.y == c2.y && c1.z == c2.z) ||
                ((Math.Abs(c1.y - c2.y) == 1) && c1.x == c2.x && c1.z == c2.z) ||
                ((Math.Abs(c1.z - c2.z) == 1) && c1.y == c2.y && c1.x == c2.x);
            return ret;
        }
    }
