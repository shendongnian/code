    public class Board
    {
       public const int Height = 8;
       public const int Width = 8;
       private Counters[Height][] Counters { get; set; }
       public Counter GetCounter(int row, int col)
       {
          return Counters[row][col];
       }
       public void Initialize() { }
       public void ExecuteMove(Counter c) { }
    }
    public class Counter
    {
       public int Row { get; set; }
       public int Column { get; set; }
    }
