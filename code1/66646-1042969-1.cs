    ArrayList generatePrimes(int numberToGenerate)
    {
        ArrayList rez = new ArrayList();
    
        rez.Add(2);
        rez.Add(3);
    
        for(int i = 5; rez.Count <= numberToGenerate; i+=2)
        {
            bool prime = true;
            for (int j = 2; j < Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                        prime = false;
                        break;
                }
            }
            if (prime) rez.Add(i);
        }
    
        return rez;
    }
