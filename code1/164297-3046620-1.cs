    int sum;
    for (int i =1; i<= 12; i++)
    {
        sum += someArray[i];
        if (i%3==0)
        {
            Console.WriteLine(sum);
            sum =0;
        }
    }
