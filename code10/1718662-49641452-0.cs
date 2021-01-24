    float input = Convert.ToSingle(Console.ReadLine());
    float factor1 = 2;
    float factor2 = 0;
    bool isPrime = true;
    
    for(; factor1 < input; factor1++)
    {
    	factor2 = input / (float)factor1;
    
    	if((int)factor2 == factor2)
    	{
    		isPrime = false;                    
    		break;
    	}
    }
    
    if(isPrime)
    {
    	Console.WriteLine($"{input} is prime.");
    }
    else
    {                
    	Console.WriteLine($"{input} is not prime. {factor1} * {factor2} = {input}");
    }
