    public struct SubAverage
    {
        public float Average;
        public int   Count;
    };
    
    static SubAverage AverageMegaList(List<float> aList)
    {
        if (aList.Count <= 500)
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
    
        SubAverage subAvg_A = AverageMegaList(aList.GetRange(0, aList.Count/2));
        SubAverage subAvg_B = AverageMegaList(aList.GetRange(aList.Count/2 + 1, aList.Count-1));
    
        SubAverage finalAnswer;
        finalAnswer.Average = subAvg_A.Average * (float)subAvg_A.Count/aList.Count + 
                              subAvg_B.Average * (float)subAvg_B.Count/aList.Count;
        finalAnswer.Count = aList.Count;
    
        Console.WriteLine("The average of {0} numbers is {1}",
            finalAnswer.Count, finalAnswer.Average);
        return finalAnswer;
    }
