    public bool IsBelowThreshold(string filename, int hours)
    {
         var threshold = DateTime.Now.AddHours(-hours);
         return System.IO.File.GetCreationTime(filename) <= threshold;
    }
