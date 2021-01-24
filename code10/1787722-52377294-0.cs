    public void CalcPi()
        {
            piEst = ((double)hits / (double)throwDarts) * 4;
            Console.WriteLine("Based off the darts thrown, Pi is approximately {0}.", piEst);
            Console.ReadLine();
        }
