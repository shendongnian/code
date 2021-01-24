    for(var indexRow = 0; indexRow < 5; indexRow++)
    {
        for(var indexCol = 0; indexCol < 5; indexCol++)
        {
            var box = new Box();
            box.vhID = (char)(((int)'a') + indexRow) + (char)(((int)'1') + indexCol);
            board[indexRow, indexCol] = box;
            
        }
    }
