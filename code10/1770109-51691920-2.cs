    int[] integerRates = new int[6];
    while(index<rates.Length)
            {
                integerRates[index] = decimal.ToInt32(rates[index]);
                index++;
            }
    highestRate = Highest(integerRates); 
    lowestRate = Lowest(integerRates);
    averageRate = Average(integerRates); 
 
