      public static class Box1
        {
            public static double length;   // Length of a box
            public static double breadth;  // Breadth of a box
            public static double height;   // Height of a box
    
            public static double Volume(double len, double bre, double hei)
            {
                double totvolume;
                totvolume = len * bre * hei;
                return totvolume;
            }
    
        }
       public static class Box2
        {
            public static double length;   // Length of a box
            public static double breadth;  // Breadth of a box
            public static double height;   // Height of a box
    
            public static double Volume(double len, double bre, double hei)
            {
                double totvolume;
                totvolume = len * bre * hei;
                return totvolume;
            }
    
        }
        public class Boxtester
        {
    
            static void Main(string[] args)
            {
                // box 1 specification
                Box1.length = 6.0;
                Box1.breadth = 7.0;
                Box1.height = 5.0;
    
                // box 2 specification
                Box2.length = 11.0;
                Box2.breadth = 16.0;
                Box2.height = 12.0;
    
                Console.WriteLine("Volume of Box1 : {0}", Box1.Volume(Box1.length, Box1.breadth, Box1.height));
                Console.WriteLine("Volume of Box1 : {0}", Box2.Volume(Box2.length, Box2.breadth, Box2.height));
    
    
                Console.ReadKey();
            }
        }
