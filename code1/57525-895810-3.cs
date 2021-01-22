    public struct SubAverage
    {
        public float Average;
        public int   Count;
    };
    
    static SubAverage AverageMegaList(List<float> aList)
    {
        if (aList.Count <= 500) // Brute-force average 500 numbers or less.
        {
            SubAverage avg;
            avg.Average = 0;
            avg.Count   = aList.Count;
            foreach(float f in aList)
            {
                avg.Average += f;
            }
            avg.Average /= avg.Count;
            return avg;
        }
    
        // For more than 500 numbers, break the list into two sub-lists.
        SubAverage subAvg_A = AverageMegaList(aList.GetRange(0, aList.Count/2));
        SubAverage subAvg_B = AverageMegaList(aList.GetRange(aList.Count/2, aList.Count-aList.Count/2));
    
        SubAverage finalAnswer;
        finalAnswer.Average = subAvg_A.Average * subAvg_A.Count/aList.Count + 
                              subAvg_B.Average * subAvg_B.Count/aList.Count;
        finalAnswer.Count = aList.Count;
    
        Console.WriteLine("The average of {0} numbers is {1}",
            finalAnswer.Count, finalAnswer.Average);
        return finalAnswer;
    }
