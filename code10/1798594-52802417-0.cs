    Random rng1 = new Random();
    bool done = false;
    int win;
    int lose;
    win = 0;
    lose = 0;
    int lose1;
    int lose2;
    int win1;
    int win2;
    win1 = 0;
    win2 = 0;
    lose1 = 0;
    lose2 = 0;
    int roll1 = 0;
    
    while (done == false)
    {
        int roll = rng1.Next(0, 2);
        Console.WriteLine(roll);
        if (roll == 1)
        {
            win++;
            win1++; // A change
            if (lose1 < lose2)
            {
                lose2 = lose1;
                lose1 = 0;
            }
        }
        else
        {
            lose++;
            lose1 = lose;
    
            if (win1 >= win2)
            {
                win2 = win1;
            }
            win1 = 0; // A change
        }
    
        roll1++;
        if (roll1 == 100)
        {
            done = true;
        }
    }
    
    Console.WriteLine("lose streak" + lose2 + " win streak" + win2 + " lose" + lose + " win" + win);
    Console.ReadKey();
