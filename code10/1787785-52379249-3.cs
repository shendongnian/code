    public class SpaceAge
    {
        public long seconds;
        public SpaceAge(long seconds)
        {
            this.seconds = seconds;
            Console.WriteLine("Space Age in Seconds:" + seconds); 
        }
        public double OnEarth()
        {
            //the "D" at the end of the number means it is a double, not an int.
            double result = seconds / 31557600D;
            return result;
        }
        public double OnMercury()
        {
            double result = seconds * 0.2408467D;
            return result;
        }
    }  
