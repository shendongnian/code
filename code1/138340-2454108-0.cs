    var result = new double[] {
        Double.MinValue, Double.MinValue, Double.MinValue,
        Double.MinValue, Double.MinValue, Double.MinValue };
    
    for (int i = 0; i < allCoordinates.Length; i += 6) 
    {
        for (int j = 0; i < 6; i++)
        {
            if (allCoordinates[i+j] > result[j])
                result[j] = allCoordinates[i+j];
        }
    }
