    var C = new int[,,]
    {
        { 
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 }
        },
        {
            { 11, 12, 13 },
            { 14, 15, 16 },
            { 17, 18, 19 }
        },
        {
            { 21, 22, 23 },
            { 24, 25, 26 },
            { 27, 28, 29 }
        }
    };
    
    /* From first dimension slice index 2
     * { 21, 22, 23 },
     * { 24, 25, 26 },
     * { 27, 28, 29 }
     */
    var D = new View<int>(C, 0, 2);
    
    D[1, 1] = 0;
    Console.WriteLine(C[2, 1, 1]); // 0
    
    /* From third dimension slice index 0
     * { 1, 4, 7 },
     * { 11, 14, 17 },
     * { 21, 24, 27 }
     */
    var E = new View<int>(C, 2, 0);
    
    E[2, 0] = 0;
    Console.WriteLine(C[2, 0, 0]); // 0
