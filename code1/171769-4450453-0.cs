    int ceilingNumber = 1000000;
    int myPrimes = 0;
    
    
    BitArray myNumbers = new BitArray(ceilingNumber, true);
    
    for(int x = 2; x < ceilingNumber; x++)
        if(myNumbers[x])
        {
            for(int y = x * 2; y < ceilingNumber; y += x)
                myNumbers[y] = false;
        }
    
    
    for(int x = 2; x < ceilingNumber; x++)
        if(myNumbers[x])
        {
            myPrimes++;
            Console.Out.WriteLine(x);
    
        }
    
    Console.Out.WriteLine("======================================================");
    
    Console.Out.WriteLine("There is/are {0} primes between 0 and {1} ",myPrimes,ceilingNumber);
    
    Console.In.ReadLine();
