    Random rnd = new Random();
    int[] valueCount = new int[6];
    for (int i=0; i<5; i++)
    {
        dice[rnd.next(0,6)]++;
    }
    //you have kept track of each value.
    if (valueCount.Any(c => c == 3))
        //3 of a kind
