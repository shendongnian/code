      static void Main(string[] args)
                {
                     Console.WriteLine("Please enter your first test score");
        
                //variables
                double testScore = double.Parse(Console.ReadLine());
                double average = 0;
        
                for (int count = 1; count <= 5; count++) // Start the count from 0-4
                {
                    //get the total
                    average = average + testScore;
        
                    Console.WriteLine("Please enter your other test score");
                    testScore = double.Parse(Console.ReadLine());
                    average = average / count;
                    //Calculate and display 
                    Console.WriteLine("The average of your test score is {0}", average);
                }
        
        
                Console.ReadKey();
              
                }
