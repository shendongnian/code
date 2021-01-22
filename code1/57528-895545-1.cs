    using System;
    using System.Collections.Generic;
    namespace LookupTable
    {
      internal class Program
      {
        private static readonly Dictionary<SizeSpeedKey, double> lookupTable =
          new Dictionary<SizeSpeedKey, double>
          {
            {new SizeSpeedKey("6x5", 500), 0.1},
            {new SizeSpeedKey("6x5", 750), 0.5},
            {new SizeSpeedKey("6x4", 500), 0.01},
            {new SizeSpeedKey("6x4", 750), 0.1},
            {new SizeSpeedKey("8x5", 500), 0.5},
            {new SizeSpeedKey("8x5", 750), 0.9},
          };
        private static void Main(string[] args)
        {
          // these will of course need to be read from the user
          var size = "6x4";
          var speed = 500;
          Console.WriteLine("For size = {0} and speed = {1}, the pressure will be {2}", size, speed, lookupTable[new SizeSpeedKey(size, speed)]);
          Console.ReadLine();
        }
      }
    }
