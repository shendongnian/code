    using (var input = File.OpenText("filename"))
    {
        var maxCounts = new long[]{0,0,0,0,0,0,0,0,0,0};
        var latestCounts = new long[]{0,0,0,0,0,0,0,0,0,0};
        char prevChar = ' ';
    
        word digits = 0;
        while (!input.EndOfStream)
        {
            var c = input.Read();
    
            // If the character is a digit, set the corresponding bit
            if (char.IsDigit(c))
            {
                digits |= (1 << (c-'0'));
                prevChar = c;
                continue;
            }
    
            // test here to prevent resetting counts when there are multiple non-digit
            // characters between numbers.
            if (!char.IsDigit(prevChar))
            {
                continue;
            }
            prevChar = c;
    
            // digits has a bit set for every digit
            // that occurred in the number.
            // Update the counts arrays.
    
            // For each of the first 10 bits, update the corresponding count.
            for (int i = 0; i < 10; ++i)
            {
                if ((digits & 1) == 1)
                {
                    ++latestCounts[i];
                    if (latestCounts[i] > maxCounts[i])
                    {
                        maxCounts[i] = latestCounts[i];
                    }
                }
                else
                {
                    latestCounts[i] = 0;
                }
                // Shift the next bit into place.
                digits >> 1;
            }
            digits = 0;
        }
    }
