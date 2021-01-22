    bool IsPrime(int input)
            {
                //2 and 3 are primes
                if (input == 2 || input == 3)
                    return true; 
                else if (input % 2 == 0 || input % 3 == 0)
                    return false;     //Is divisible by 2 or 3?
                else
                {
                    for (int i = 5; i * i <= input; i += 6)
                    {
                        if (input % i == 0 || input % (i + 2) == 0)
                            return false;
                    }
                    return true;
                }
            }
