    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Zurg
    {
      class Program
      {
        static readonly Toy[] toys = new Toy[]{
            new Toy("Buzz", 5),
            new Toy("Woody", 10),
            new Toy("Rex", 20),
            new Toy("Ham", 25),
            };
        static readonly int totalTorch = 60;
        static void Main()
        {
          Console.WriteLine(Go(new State(toys, new Toy[0], totalTorch, "")).Message);
        }
        static State Go(State original)
        {
          var final = (from first in original.Start
                       from second in original.Start
                       where first != second
                       let pair = new Toy[]
                       {
                         first,
                         second
                       }
                       let flashlight = original.Flashlight - pair.Max(t => t.Time)
                       select Return(new State(
                         original.Start.Except(pair),
                         original.Finish.Concat(pair),
                         flashlight,
                         original.Message + string.Format(
                          "Go {0}. {1} min remaining.\n",
                          string.Join(", ", pair.Select(t => t.Name)),
                          flashlight)))
                       ).Aggregate((oldmax, cur) => cur.Flashlight > oldmax.Flashlight ? cur : oldmax);
          return final;
        }
        static State Return(State original)
        {
          if (!original.Start.Any())
            return original;
          var final = (from toy in original.Finish
                       let flashlight = original.Flashlight - toy.Time
                       let toyColl = new Toy[] { toy }
                       select Go(new State(
                         original.Start.Concat(toyColl),
                         original.Finish.Except(toyColl),
                         flashlight,
                         original.Message + string.Format(
                          "Return {0}. {1} min remaining.\n",
                          toy.Name,
                          flashlight)))
                       ).Aggregate((oldmax, cur) => cur.Flashlight > oldmax.Flashlight ? cur : oldmax);
          return final;
        }
      }
      public class Toy
      {
        public string Name { get; set; }
        public int Time { get; set; }
        public Toy(string name, int time)
        {
          Name = name;
          Time = time;
        }
      }
      public class State
      {
        public Toy[] Start { get; private set; }
        public Toy[] Finish { get; private set; }
        public int Flashlight { get; private set; }
        public string Message { get; private set; }
        public State(IEnumerable<Toy> start, IEnumerable<Toy> finish, int flashlight, string message)
        {
          Start = start.ToArray();
          Finish = finish.ToArray();
          Flashlight = flashlight;
          Message = message;
        }
      }
    }
