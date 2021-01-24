    using System;
    
    namespace Gamble
    {
        public class Dice
        {
            class Program
            {
                static void Main(string[] args)
                {
                    const int possiblities = 2;
    
                    Random rng1 = new Random();
                    int[] side = new int[possiblities];
                    int[] maxSequences = new int[possiblities];
      
                    int lastRoll = 0;
                    int sequenceCount = 0;
                    for (int rollCount = 0; rollCount < 100; rollCount++)
                    {
                        int roll = rng1.Next(0, possiblities);
                        Console.WriteLine(roll);
                        if (lastRoll != roll)
                        {
                            if (maxSequences[lastRoll] < sequenceCount) maxSequences[lastRoll] = sequenceCount;
                            sequenceCount = 0;
                            lastRoll = roll;
                        }
                        sequenceCount++;
    
                        side[roll]++;
                    
                    }
    
                    Console.WriteLine("lose streak:" + maxSequences[0] + " win streak:" + maxSequences[1] + " lose:" + side[0] + " win:" + side[1]);
                    Console.ReadKey();
    
                 }
            }
        }
   }
