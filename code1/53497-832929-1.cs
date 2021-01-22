    // A word is 32-bits
    void CountBytes(int numberOfWords)
    {
        uint[] numbers = new uint[numberOfWords];
        while(true)
        {
            // Show most-significant first
            for (int i=numbers.Length-1; i>=0; i--)
            {
                Console.Write(Convert.ToString(numbers[i], 2).PadLeft(32, '0'));
            }
            // Hit max on all uint's, bail
            bool done = true;
            for (int i=numbers.Length-1; i >= 0; i--)
            {
                if (numbers[i] != uint.MaxValue)
                {
                    done = false;
                    break;
                }
            }
            if (done)
            {
                break;
            }
            // Check for overflow
            for (int i=numbers.Length-2; i >= 0; i--)
            {
                // Overflow for numbers[i] is if it and all beneath it are MaxValue
                bool overflow = true;
                for (int k=i; k>=0; k--)
                {
                    if (numbers[k] != uint.MaxValue)
                    {
                        overflow = false;
                        break;
                    }
                }
                if (overflow)
                {
                    numbers[i+1]++;
                    numbers[i] = 0;
                }
            }
            // Increment counter
            numbers[0]++;
        }
    }
