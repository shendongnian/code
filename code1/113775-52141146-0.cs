    void cc() { Console.Clear(); }
    void cr() { Console.ReadKey(); }
    
    byte Sleeptimer = 90;
    void sleepy() { System.Threading.Thread.Sleep(Sleeptimer); }
    
      
    
    
    string[] Loading = { @"-- ", @"\  ", @"|  ", @"/  ", "Loading", " complete!" };
    
    for (byte i = 0; i <= 15; i++)
    {
        cc();
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(Loading[0] + Loading[4]);
        sleepy();
        cc();
    
        Console.WriteLine(Loading[1] + Loading[4]);
        sleepy();
        cc();
    
        Console.WriteLine(Loading[2] + Loading[4]);
        sleepy();
        cc();
    
        Console.WriteLine(Loading[3] + Loading[4]);
        sleepy();
        cc();
    
        if (i == 15) {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Loading[4] + Loading[5]);
    
            cc();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Next();
        }
    }
    /*
        Now i feel even more noob while reading your code.
        I'm a newbie in programing.
    
        Guess this way would work if i just incfement the index of each Loading down below right?
        Learned too much today, forgot how this exactly works, to increment or to change the index i'd lile to acces
    
        Console.WriteLine(Loading[2] + Loading[4]);
        sleepy();
        cc();
    
    */
