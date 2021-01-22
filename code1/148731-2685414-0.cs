    int licenses = 136;
    int sum = 0;
    while (licenses > 0)
    {
        if (licenses >= 50)      { sum += 7999; licenses -= 50; }
        else if (licenses >= 20) { sum += 3499; licenses -= 20; }
        else if (licenses >= 10) { sum += 1899; licenses -= 10; }
        else if (licenses >= 5)  { sum += 999;  licenses -= 5; }
        else                     { sum += 299;  licenses -= 1; }
    }
    // sum == 22694
