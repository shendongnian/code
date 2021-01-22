    public double StandardDeviation(List<double> valueList, double ma)
    {
       double xMinusMovAvg = 0.0;
       double Sigma = 0.0;
       int k = valueList.Count;
      foreach (double value in valueList){
         xMinusMovAvg = value - ma;
         Sigma = Sigma + (xMinusMovAvg * xMinusMovAvg);
      }
      return Math.Sqrt(Sigma / (k - 1));
    }       
