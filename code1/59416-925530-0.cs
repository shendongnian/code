    class Program
    {
        static void Main(string[] args)
        {
            List<CarSpecs> cars = new List<CarSpecs>();
            cars.Sort(CarSpecs.CompareCarSpecs);
        }
    }
    public class CarSpecs
    {
        public string CarName { get; set; }
        public string CarMaker { get; set; }
        public DateTime CreationDate { get; set; }
        public static int CompareCarSpecs(CarSpecs x, CarSpecs y)
        {
            return x.CreationDate.CompareTo(y.CreationDate);
        }
    }
