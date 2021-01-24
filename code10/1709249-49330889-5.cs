    static void Move(Knight knight, Board board, Point destination, int counter, Trace trace)
    {
        board.Set(knight.X, knight.Y, counter);
        if (knight.IsInPoint(destination))
        {
            if (!trace.IsShorterThen(counter))
            {
                trace.Counter = counter;
                trace.Board = board;
                Console.WriteLine("Better trace");
                Console.WriteLine("Counter: " + trace.Counter);
                Console.WriteLine(trace.Board);
            }
            return;
        }
        counter++;
        Point[] moves = knight.AllPossibleMoves();
        foreach(Point point in moves)
        {
            if (board.Contains(point) && board.IsFree(point))
            {
                knight.MoveTo(point);
                Move(knight, board.GetCopy(), destination, counter, trace);
            }
        }
    }
