    var minValues = new double[] { Double.MaxValue, Double.MaxValue, Double.MaxValue };
    var maxValues = new double[] { Double.MinValue, Double.MinValue, Double.MinValue };
    
    for (int i = 0; i < allCoordinates.Length; i += 6) 
    {
        for (int j = 0; i < 3; i++)
        {
            if (allCoordinates[i+j] < minValues[j])
                minValues[j] = allCoordinates[i+j];
            if (allCoordinates[i+j+3] > maxValues[j])
                maxValues[j] = allCoordinates[i+j+3];
        }
    }
