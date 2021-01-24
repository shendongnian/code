    public class ASimpleCalculation : ISizeCalculator
    {
        public string GetSize(int width, int length, int height)
        {
            return string.Format("{0} x {1} x {2}", width, length, height);
        }
    }
    public class AnotherCalculation : ISizeCalculator
    {
        public string GetSize(int width, int length, int height)
        {
            return (width * length * height).ToString();
        }
    }
    ...
    ...
