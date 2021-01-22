    void simplify(int[] numbers)
    {
        for (int divideBy = 50; divideBy > 0; divideBy--)
        {
            bool divisible = true;
            foreach (int cur in numbers)
            {   
                //check for divisibility
                if ((int)(cur/divideBy)*divideBy!=cur){
                    divisible = false;
                    break;
                }
            }
            if (divisible)
            {
                for (int i = 0; i < numbers.GetLength(0);i++ )
                {
                    numbers[i] /= divideBy;
                }
            }
        }
    }
