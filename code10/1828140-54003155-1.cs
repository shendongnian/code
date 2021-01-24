    for (int n = 0; n < fftResults.Length / 2; n+= binsPerPoint)
    {
        // averaging out bins
        double yPos = 0;
        for (int b = 0; b < binsPerPoint; b++)
        {
            yPos += GetYPosLog(fftResults[n+b]);
        }
        AddResult(n / binsPerPoint, yPos / binsPerPoint);
    }
