    public class MovingAverageCalculator {
        /// <summary>
        /// Maximum number of numbers this moving average calculator can hold.
        /// </summary>
        private readonly int maxElementCount;
        
        /// <summary>
        /// Numbers which will be used for calculating moving average.
        /// </summary>
        private readonly int[] currentElements;
        
        /// <summary>
        /// At which index the next number will be added.
        /// </summary>
        private int currentIndex;
        
        /// <summary>
        /// How many elements are there currently in this moving average calculator.
        /// </summary>
        private int currentElementCount;
        
        /// <summary>
        /// Current total of all the numbers that are being managed by this moving average calculator
        /// </summary>
        private double currentTotal;
        
        /// <summary>
        /// Current Average of all the numbers.
        /// </summary>
        private double currentAvg;
        /// <summary>
        /// An object which can calcauclate moving average of given numbers.
        /// </summary>
        /// <param name="period">Maximum number elements</param>
        public MovingAverageCalculator(int period) {
            maxElementCount = period;
            currentElements = new int[maxElementCount];
            currentIndex = 0;
            currentTotal = 0;
            currentAvg = 0;
        }
        /// <summary>
        /// Adds an item to the moving average series then updates the average.
        /// </summary>
        /// <param name="number">Number to add.</param>
        public void AddElement(int number){
            // You can only have at most maximum elements in your moving average series.
            currentElementCount = Math.Min(++currentElementCount, maxElementCount);
            // IF your current index reached the maximum allowable number then you must reset
            if (currentIndex == maxElementCount){
                currentIndex = 0;
            }
            // Copy the current index number to the local variable
            var temp = currentElements[currentIndex];
            // Substract the value from the current total because it will be replaced by the added number.
            currentTotal -= temp;
            // Add the number to the current index
            currentElements[currentIndex] = number;
            // Increase the total by the added number.
            currentTotal += number;
            // Increase index
            currentIndex++;
            // Calculate average
            currentAvg = (double)currentTotal / currentElementCount;
        }
        /// <summary>
        /// Gets the current average
        /// </summary>
        /// <returns>Average</returns>
        public double GetAverage() => currentAvg;
    }
