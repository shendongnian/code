     private static double AverageReading() {
       if (intRecordCount == 0) 
         return 0.0;
       double dblTotal = 0.0; // <- 0.0, not intRecordCount
       // probably, condition should be "i < intLoanNumber.Length" not "i < intRecordCount"
       for (int i = 0; i < intRecordCount; ++i)
         dblTotal += intLoanNumber[i];
       // probably, "dblTotal / intLoanNumber.Length" instead of "dblTotal / intRecordCount"
       return dblTotal / intRecordCount;   
     }
