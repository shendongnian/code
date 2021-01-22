      public class Dice
      {
        private Random rnd = new Random();
    
        Int32 _DiceSize;
        public Int32 _NoOfDice;
        public Dice(Int32 dicesize)
        {
          if (dicesize <= 0)
          {
            throw new ApplicationException("Dice Size cant be less than 0 or 0");
          }
    
          this._DiceSize = dicesize;
        }
        public string Roll()
        {
          
          if (_NoOfDice <= 0)
          {
            throw new ApplicationException("No of dice cant be less than 0 or 0");
          }
          // to capture just the counts
          int[] roll = new int[_DiceSize];
          for (int i = 0; i < _NoOfDice; i++)
          {
            roll[rnd.Next(roll.Length)]++;
          }
          StringBuilder result = new StringBuilder();
          Int32 Total = 0;
          Console.WriteLine("Rolling.......");
          for (Int32 i = 0; i < roll.Length; i++)
          {
            Total += roll[i];
            result.AppendFormat("{0}:\t was rolled\t{1}\t times\n", i + 1, roll[i]);
          }
          result.AppendFormat("\t\t\t......\n");
          result.AppendFormat("TOTAL: {0}", Total);
          return result.ToString();
        }
      }
      class Program
      {
        static void Main(string[] args)
        {
          Console.WriteLine("Enter no of dice size");
          int dicesize = Convert.ToInt32(Console.ReadLine());
          Console.WriteLine("How many times want to play");
          int noofplay = Convert.ToInt32(Console.ReadLine());
          Dice obj = new Dice(dicesize);
          obj._NoOfDice = noofplay;
          Console.WriteLine(obj.Roll());
          Console.WriteLine("Press enter to exit");
          Console.ReadKey();
        }
      }
