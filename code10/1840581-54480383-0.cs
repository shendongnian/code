    namespace CSharp_Tuples
    {
        class Program
        {
            static void Main(string[] args)
            {
                string PhoneNumbers = "+92315 +92316 +92317 +92318";
    
                //var separateNumbers = GetIndividualNumbers(PhoneNumbers);
    
                //string firstNumber = separateNumbers.Item1;
                //string secondNumber = separateNumbers.Item2;
                //string thirdNumber = separateNumbers.Item3;
                //string fourthNumber = separateNumbers.Item4;
    
                //Console.WriteLine(firstNumber);
                //Console.WriteLine(secondNumber);
                //Console.WriteLine(thirdNumber);
                //Console.WriteLine(fourthNumber);
    
    
                var numbers = Cast(usingAnonymouseObject(PhoneNumbers), new {
                                                                            firstNumber = "",
                                                                            secondNumer = "",
                                                                            thirdNumber = "",
                                                                            fourthNumber = ""
                                                                            });
                Console.WriteLine("firstNumber : " + numbers.firstNumber);
                Console.WriteLine("secondNumber : " + numbers.secondNumer);
                Console.WriteLine("thirdNumber : " + numbers.thirdNumber);
                Console.WriteLine("fourthNumber : " + numbers.fourthNumber);
    
    
            }
            //static Tuple<string, string, string, string> GetIndividualNumbers(string allNumbers)
            //{
            //    string[] numbers  = allNumbers.Split(' ');
            //    return Tuple.Create<string,string,string,string>(numbers[0],numbers[1],numbers[2],numbers[3]);
            //}
    
            static object usingAnonymouseObject(string allNumbers)
            {
                string[] numbers = allNumbers.Split(' ');
                return new { firstNumber = numbers[0], secondNumer = numbers[1], thirdNumber = numbers[2], fourthNumber = numbers[3] };
            }
    
            static T Cast<T>(object obj, T type)
            {
                return (T)obj;
            }
        }
    }
----------
