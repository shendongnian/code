    Rn[] := 0.5 * RandomInteger[{-1, 1}];
    monshft1 = Table[{ 1 , 10 + Rn[] , 15 + Rn[] }, {150}];  // 1
    monshft2 = Table[{ 1 , 12 + Rn[] , 17 + Rn[] }, {150}];  // 2
    wedshft1 = Table[{ 3 , 10 + Rn[] , 15 + Rn[] }, {150}];  // 3
    wedshft2 = Table[{ 3 , 14 + Rn[] , 17 + Rn[] }, {150}];  // 4
    frishft1 = Table[{ 5 , 10 + Rn[] , 15 + Rn[] }, {150}];  // 5
    frishft2 = Table[{ 5 , 11 + Rn[] , 15 + Rn[] }, {150}];  // 6
    monexcp  = Table[{ 1 , 7  + Rn[] , 9  + Rn[] }, {2}];    // 7
