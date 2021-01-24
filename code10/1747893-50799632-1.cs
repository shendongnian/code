    double val = 444.3;
    double step1 = val/10;                 // 44.43
    double step2 = Math.Round(step1, MidpointRounding.AwayFromZero); // 44
    int step3 = (int)step2 * 10;           // 440
    int step4 = step3 - 1;                 // 439
