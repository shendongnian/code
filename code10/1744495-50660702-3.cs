    using System;
    class Program
    {
        static void Main(string[] args)
        {
            var calculator = new Calculator();
            var input = GetNumbers();
            calculator.Add(input);
            Console.WriteLine(calculator.Add(input));
        }
        public static int[] GetNumbers()
        {
          Console.WriteLine("Enter Numbers Seperated With a Space");
          string input = Console.ReadLine(); //Get user input with this
          string[] arr = input.Split(' '); //Split the input at spaces
          int[] output = new int[arr.Length]; //create in array of same length
          for(int i = 0; i < output.Length; i++)
          {
              output[i] = Int32.Parse(arr[i]); //parse every value and add to int array
          }
          return output;
        }
    }
    public class Calculator
    {
        public int Add(params int[] numbers)
        {
            var sum = 0;
            foreach (var number in numbers)
            {
                sum += number;
            }
            return sum;
        }
    }
