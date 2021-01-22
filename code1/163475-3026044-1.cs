     private void testIfPrimeSerial(int suspectPrime)
    {
        for (int i = 2; i <= Math.Sqrt((double) suspectPrime); i++)
        {
            if ((suspectPrime % i) == 0)
            {
                return;
            }
        }
        this.temp.Add(suspectPrime);
    }
