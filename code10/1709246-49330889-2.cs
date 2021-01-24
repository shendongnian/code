    static void Main(string[] args)
    {
        Knight knight = new Knight(0, 0);
        Board board = new Board(8, 8);
        Point destination = new Point(0, 4);
        Trace bestTrace = new Trace();
        MoveFirstSolution(knight, board, destination, 1, bestTrace);
    
        Console.WriteLine("Best trace: " + bestTrace.Counter);
        Console.WriteLine(bestTrace.Board);
        Console.ReadLine();
    }
