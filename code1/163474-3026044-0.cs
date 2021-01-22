    private static void testIfPrimeSerial(int suspectPrime)
    {
        int VB$t_i4$L0 = (int) Math.Round(Math.Sqrt((double) suspectPrime));
        for (int i = 2; i <= VB$t_i4$L0; i++)
        {
            if ((suspectPrime % i) == 0)
            {
                return;
            }
        }
        temp.Add(suspectPrime);
    }
 
