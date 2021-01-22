    public float LatchTimeStdev()
    {
        float mean = LatchTimeMean();
        float returnValue = 0;
        foreach (ValveData value in m_ValveResults)
        {
            returnValue += Math.Pow(value.LatchTime - mean, 2); 
        }
        return Math.Sqrt(returnValue / m_ValveResults.Count-1));
    }
