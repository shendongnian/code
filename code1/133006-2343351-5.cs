    public string AspectRatioAsString(double ratio)      
    { 
        var results = from commonRatio in commonRatios
                      select new {
                          Ratio = commonRatio, 
                          Diff = Math.Abs(ratio - commonRatio.AsDouble())};
    
        var smallestResult = results.Min(x=>x.Diff);
    
        return String.Format("{0}:{1}", smallestResult.Ratio.X, smallestResult.Ratio.Y);
    }
         
