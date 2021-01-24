        static double HeightInInches(double F, double I)
    {
        if (F < 2 || F > 7 || I < 0 || I > 11)
        {
            Console.WriteLine("Invalid Height");
            //return something here
        }
        else
        {
            double IncheHeight = F * 12 + I;
            return IncheHeight;
        }
    }
