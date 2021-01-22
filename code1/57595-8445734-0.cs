    /// <summary>
    /// Calculates standard deviation, same as MATLAB std(X,0) function
    /// <seealso cref="http://www.mathworks.co.uk/help/techdoc/ref/std.html"/>
    /// </summary>
    /// <param name="values">enumumerable data</param>
    /// <returns>Standard deviation</returns>
    public static double GetStandardDeviation(this IEnumerable<double> values)
    {
    	//validation
    	if (values == null)
    		throw new ArgumentNullException();
    
    	int lenght = values.Count();
    
    	//saves from devision by 0
    	if (lenght == 0 || lenght == 1)
    		return 0;
    
    	double sum = 0.0, sum2 = 0.0;
    
    	for (int i = 0; i < lenght; i++)
    	{
    		double item = values.ElementAt(i);
    		sum += item;
    		sum2 += item * item;
    	}
    
    	return Math.Sqrt((sum2 - sum * sum / lenght) / (lenght - 1));
    }
