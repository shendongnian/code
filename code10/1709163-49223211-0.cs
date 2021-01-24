        static void Main(string[] args)
        {
            string fraction = GetSimplifiedFraction("-12/126");// Here We are passing the fraction we want to simplyfy
            Console.WriteLine(fraction);
        }
        public static string GetSimplifiedFraction(string fraction)
        {
            string[] numbers = fraction.Split('/');// spliting the fraction to get numerator and denominator
            int numrator = int.Parse(numbers[0]);
            int denomenator = int.Parse(numbers[1]);
            List<int> numeratorFactors = GetFactors(numrator);// Getting the List of Fraction of the numerator in descending order
            List<int> denominatorFactors = GetFactors(denomenator);// Getting the List of Fraction of the numerator in descending order
            int commonFactor = int.MinValue;
            if (numeratorFactors.Count > denominatorFactors.Count)// Here we checking which fraction has more number of Factors. This is required to find the greatest common factor between both the numbers
            {
                foreach (var num in numeratorFactors)
                {
                    if (denominatorFactors.Contains(num))
                    {
                        commonFactor = num;// Here we are assigning the greatest common Factor
                        break;
                    }
                }
            }
            else
            {
                foreach (var num in denominatorFactors)
                {
                    if (numeratorFactors.Contains(num))
                    {
                        commonFactor = num;// Here we are assigning the greatest common Factor
                        break;
                    }
                }
            }
            if (commonFactor == int.MinValue)// If there is no common factor than the fraction can not be simplified hence returing the same fraction Back
            {
                return fraction;
            }
            else
            {
                numrator = numrator / commonFactor;// Once we found the common factor we need to divide the numerator and denominator with the fraction
                denomenator = denomenator / commonFactor;
                return numrator.ToString() + "/" + denomenator.ToString();// here we are forming the simplified fraction
            }
        }
        public static List<int> GetFactors(int number)
        {
            if (number < 0) number = -number;
            List<int> factors = new List<int>();
            factors.Add(number);
            for(int i = 1; i < number / 2; i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                }
            }
            return factors.OrderByDescending(_=>_).ToList();//sorting the fraction in descending
        }
    
