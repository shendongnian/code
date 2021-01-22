    static public TimeSpan[] Reduce(TimeSpan[] spans, int blockLength)
    {
        TimeSpan[] avgSpan = new TimeSpan[original.Count / blockLength];
        int currentIndex = 0;
        
        for (int outputIndex = 0;
             outputIndex < avgSpan.Length; 
             outputIndex++)
        {
            long totalTicks = 0;
            for (int sampleIndex = 0; sampleIndex < blockLength; sampleIndex++)
            {
                totalTicks += spans[currentIndex].Ticks;
                currentIndex++;
            }
            avgSpan[outputIndex] =
                TimeSpan.FromTicks(totalTicks / blockLength);
        }
        return avgSpan;
    }
