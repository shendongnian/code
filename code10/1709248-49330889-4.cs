    static bool MoveFirstSolution(Knight knight, Board board, Point destination, int counter, Trace trace)
    {
        board.Set(knight.X, knight.Y, counter);
        if (knight.IsInPoint(destination))
        {       
            //trace is an object to store found path         
            trace.Counter = counter;
            trace.Board = board;                   
            return true;
        }
        counter++;
        Point[] moves = knight.AllPossibleMoves();
        foreach (Point point in moves)
        {
            if (board.Contains(point) && board.IsFree(point))
            {
                knight.MoveTo(point);
                if (MoveFirstSolution(knight, board.GetCopy(), destination, counter, trace))
                {
                    return true;
                }
            }
        }
        return false;
    }
