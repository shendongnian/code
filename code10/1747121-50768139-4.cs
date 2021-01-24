    var width = 10;
    var height = 10;
            
    for (var x = 0; x < width; ++x)
    {
        for (var y = 0; y < height; ++y)
        {
            var isFirstRow = x == 0;
            var isLastRow = x == width - 1;
            var isFirstColumn = y == 0;
            var isLastColumn = y == height - 1;
            var isBorderPosition = isFirstRow || isLastRow || isFirstColumn || isLastColumn;
            if (isBorderPosition)
            {
                Console.Write("*");
                if (isLastColumn)
                {
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.Write(" ");
            }
        }
    }
