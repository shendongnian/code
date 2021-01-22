    class ConversionClass
    {
        private static Dictionary<int, string> InitialNumbers = new Dictionary<int, string>();
        private static Dictionary<int, string> MultipleOfTen = new Dictionary<int, string>();
        private static Dictionary<int, string> MultipleOfHundered = new Dictionary<int, string>();
        private static void InitializeStatic()
        {
            //InitialNumbers.Add(0, "zero");
            InitialNumbers.Add(1, "one");
            InitialNumbers.Add(2, "two");
            InitialNumbers.Add(3, "three");
            InitialNumbers.Add(4, "four");
            InitialNumbers.Add(5, "five");
            InitialNumbers.Add(6, "six");
            InitialNumbers.Add(7, "seven");
            InitialNumbers.Add(8, "eight");
            InitialNumbers.Add(9, "nine");
            InitialNumbers.Add(10, "ten");
            InitialNumbers.Add(11, "eleven");
            InitialNumbers.Add(12, "tweleve");
            InitialNumbers.Add(13, "thirteen");
            InitialNumbers.Add(14, "fourteen");
            InitialNumbers.Add(15, "fifteen");
            InitialNumbers.Add(16, "sixteen");
            InitialNumbers.Add(17, "seventeen");
            InitialNumbers.Add(18, "eighteen");
            InitialNumbers.Add(19, "nineteen");
            MultipleOfTen.Add(1, "ten");
            MultipleOfTen.Add(2, "twenty");
            MultipleOfTen.Add(3, "thirty");
            MultipleOfTen.Add(4, "fourty");
            MultipleOfTen.Add(5, "fifty");
            MultipleOfTen.Add(6, "sixty");
            MultipleOfTen.Add(7, "seventy");
            MultipleOfTen.Add(8, "eighty");
            MultipleOfTen.Add(9, "ninety");
            MultipleOfHundered.Add(2, "hundred");                      //                100
            MultipleOfHundered.Add(3, "thousand");                     //              1 000
            MultipleOfHundered.Add(4, "thousand");                     //             10 000
            MultipleOfHundered.Add(5, "thousand");                     //            100 000
            MultipleOfHundered.Add(6, "million");                      //          1 000 000
            MultipleOfHundered.Add(7, "million");                      //        100 000 000
            MultipleOfHundered.Add(8, "million");                      //      1 000 000 000
            MultipleOfHundered.Add(9, "billion");                      //  1 000 000 000 000
        }
        public static void Main()
        {
            InitializeStatic();
            Console.WriteLine("Enter number :");
            var userInput = Console.ReadLine();
            double userValue ;
            if (double.TryParse(userInput, out userValue))  // userValue = 193524019.50
            {
                int decimalPortion = (int)userValue;
                //var fractionPortion = Math.Ceiling(((userValue < 1.0) ? userValue : (userValue % Math.Floor(userValue))) * 100);
                int fractionPortion = (int)(userValue * 100) - ((int)userValue * 100);
                int digit; int power;
                StringBuilder numberInText = new StringBuilder();
                
                while (decimalPortion > 0)
                {
                    GetDigitAndPower(decimalPortion, out digit, out power);
                    numberInText.Append(ConvertToText(ref decimalPortion, ref digit, ref power));
                    if (decimalPortion > 0)
                    {
                        decimalPortion = GetReminder(decimalPortion, digit, power);
                    }
                }
                numberInText.Append(" point ");
                while (fractionPortion > 0)
                {
                    GetDigitAndPower(fractionPortion, out digit, out power);
                    numberInText.Append(ConvertToText(ref fractionPortion, ref digit, ref power));
                    if (fractionPortion > 0)
                    {
                        fractionPortion = GetReminder(fractionPortion, digit, power);
                    }
                }
                Console.WriteLine(numberInText.ToString());
            }
            Console.ReadKey();
        }
                
        private static int GetReminder(int orgValue, int digit, int power)
        {
            int returningValue = orgValue - (digit * (int)Math.Pow(10, power));
            return returningValue;
        }
        private static void GetDigitAndPower(int originalValue, out int digit, out int power)
        {
            for (power = 0, digit = 0; power < 10; power++)
            {
                var divisionFactor = (int)Math.Pow(10, power);
                int operationalValue = (originalValue / divisionFactor);
                if (operationalValue <= 0)
                {
                    power = power - 1;
                    digit = (int)(originalValue / Math.Pow(10, power));
                    break;
                }
            } 
        }
        private static string ConvertToText(ref int orgValue, ref int digit, ref int power)
        {
            string numberToText = string.Empty;
            if (power < 2)
            {
                if (InitialNumbers.ContainsKey(orgValue))
                {
                    //This is for number 1 to 19
                    numberToText = InitialNumbers[orgValue];
                    orgValue = 0;
                }
                else if (MultipleOfTen.ContainsKey(digit))
                {
                    //This is for multiple of 10 (20,30,..90)
                    numberToText = MultipleOfTen[digit];
                }
            }
            else
            {
                if (power < 4)
                {
                    numberToText = string.Format("{0} {1}", InitialNumbers[digit], MultipleOfHundered[power]);
                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    int multiplicationFactor = power / 3;
                    int innerOrgValue = (int) (orgValue / Math.Pow(10, (multiplicationFactor * 3)));
                    digit = innerOrgValue;
                    var multiple = MultipleOfHundered[power];
                    power = power - ((int)Math.Ceiling(Math.Log10(innerOrgValue)) - 1);
                    int innerPower = 0;
                    int innerDigit = 0;
                    while (innerOrgValue > 0)
                    {
                        GetDigitAndPower(innerOrgValue, out innerDigit, out innerPower);
                        var text = ConvertToText(ref innerOrgValue, ref innerDigit, ref innerPower);
                        sb.Append(text);
                        sb.Append(" ");
                        if (innerOrgValue > 0)
                        {
                            innerOrgValue = GetReminder(innerOrgValue, innerDigit, innerPower);
                        }
                    }
                    sb.Append(multiple);
                    numberToText = sb.ToString();
                }
            }
            return numberToText + " ";
        }
    }
