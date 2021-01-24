    public static void GenerateContaminant(string[,] arr)
    {
        // Iterate through every element of the array and when you find a "C", 
        // propagate the contamination recursively to its neighbors.
        for (int row = 0; row < arr.GetLength(0); row++)
        {
            for (int col = 0; col < arr.GetLength(1); col++)
            {
                if (arr[row, col] == "C") {
                    ContaminateRecurse(row, col, arr);
                }
            }
        }
        return;
    }        
    
    // Recurse from a "C" element and see if its neighbors should be contaminated.
    public static void ContaminateRecurse(int row, int col, string[,] arr)
    {
        arr[row, col] = "C";
        // Top Neighbor
        if (isValid(row-1, col, arr)) {
            ContaminateRecurse(row-1, col, arr);
        }
        // Bottom Neighbor
        if (isValid(row+1, col, arr)) {
            ContaminateRecurse(row+1, col, arr);
        }
        // Left Neighbor
        if (isValid(row, col-1, arr)) {
            ContaminateRecurse(row, col-1, arr);
        }
        // Right Neighbor
        if (isValid(row, col+1, arr)) {
            ContaminateRecurse(row, col+1, arr);
        }
        return;
    }
    
    // Makes sure that an element index is within the bounds of the array and is a 'W'.
    public static bool isValid(int row, int col, string[,] arr) {
        if ((0 <= row && row < arr.GetLength(0)) && 
            (0 <= col && col < arr.GetLength(1)) && 
            arr[row,col] == "W") {
            return true;
        }
        else {
            return false;
        }
    }
