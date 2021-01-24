    public class Box
    {
        public double length;   // Length of a box
        public double breadth;  // Breadth of a box
        public double height;   // Height of a box
    
        public double Volume() 
        {
            double totvolume;
            totvolume = length * breadth * height;
            return totvolume;
        }
    
    }
    
    public class Boxtester
    {
    
        static void Main(string[] args)
        {
            Box Box1 = new Box();   //create new variable of type Box called Box1
            Box Box2 = new Box();   //create new variable of type Box called Box2
    
            double returnvolume;    //create variable to hold the returned data from method
    
    
            // box 1 specification
            Box1.length = 6.0;
            Box1.breadth = 7.0;
            Box1.height = 5.0;
    
            // box 2 specification
            Box2.length = 11.0;
            Box2.breadth = 16.0;
            Box2.height = 12.0;
    
    
            //Calculate and display volume of Box1
            returnvolume = Box1.Volume(); 
            Console.WriteLine("Volume of Box1 : {0}", volumebox1);                    //write return value
    
            //Calculate and display volume of Box2
            returnvolume = Box2.Volume(); 
            Console.WriteLine("Volume of Box2 : {0}", volumebox2);                    //write return value
    
            Console.ReadKey();
        }
