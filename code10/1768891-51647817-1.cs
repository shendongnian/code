    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            const int NUMBER_POINTS = 12;
            static void Main(string[] args)
            {
                List<List<float>> tests = new List<List<float>>() {
                    new List<float>() { 1,5, 10},
                    new List<float>() { 5,10, 4}
                };
                foreach (List<float> test in tests)
                {
                    List<float> output = new List<float>();
                    float midPoint = test[1];
                    if(NUMBER_POINTS % 2 == 0)
                    {
                        //even number of points
                        
                        //add lower numbers
                        float lowerDelta = (test[1] - test[0])/((NUMBER_POINTS / 2) - .5F);
                        for (int i = 0; i < NUMBER_POINTS / 2; i++)
                        {
                            output.Add(test[0] + (i * lowerDelta)); 
                        }
                        float upperDelta = (test[2] - test[1]) / ((NUMBER_POINTS / 2) - .5F); ;
                        for (int i = 0; i < NUMBER_POINTS / 2; i++)
                        {
                            output.Add(test[1] + (i * upperDelta) + (upperDelta / 2F));
                        }
                    }
                    else
                    {
                    }
                    Console.WriteLine("Numbers = {0}", string.Join("   ", output.Select(x => x.ToString())));
                }
                Console.ReadLine();
            }
        }
    }
