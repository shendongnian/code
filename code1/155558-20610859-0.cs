    public class Abc
    {
        public static void Static()
        {
        }
        public Xyz Instance;
        public void Test() //instance scope
        {
            var xyz = Instance; //calls instance member
            Static(); //calls static member
        }
    }
