    //Parallel O(n) solution for finding max kvp in a dictionary...
    ClassificationResult maxValue = new ClassificationResult(-1,-1,double.MinValue);
    Parallel.ForEach(pTotals, pTotal =>
    {
        if(pTotal.Value > maxValue.score)
        {
            Interlocked.Exchange(ref maxValue, new                
                ClassificationResult(mhSet.sequenceId,pTotal.Key,pTotal.Value)); 
        }
    });
