        //this class normalizes the plot on the Fry readability graph the same way a person would, by choosing points on the graph based on values even though
        //the y-axis is non-linear and neither axis starts at 0.  Just picking a relative point on each axis to plot the intercept of the zero and infinite scope lines
        private List<GradeLineEquation> linedefs = new List<GradeLineEquation>();
        
        public FryCalculator()
        {
            LoadLevelEquations();
        }
        private void LoadLevelEquations()
        {
            // load the estimated linear equations for each line with the 
            // grade level, Slope, and y-intercept
            linedefs.Add(new NLPTest.GradeLineEquation(1, (float)0.5, (float)22.5));
            linedefs.Add(new NLPTest.GradeLineEquation(2, (float)0.5, (float)20.5));
            linedefs.Add(new NLPTest.GradeLineEquation(3, (float)0.6, (float)17.4));
            linedefs.Add(new NLPTest.GradeLineEquation(4, (float)0.6, (float)15.4));
            linedefs.Add(new NLPTest.GradeLineEquation(5, (float)0.625, (float)13.125));
            linedefs.Add(new NLPTest.GradeLineEquation(6, (float)0.833, (float)7.333));
            linedefs.Add(new NLPTest.GradeLineEquation(7, (float)1.05, (float)-1.15));
            linedefs.Add(new NLPTest.GradeLineEquation(8, (float)1.25, (float)-8.75));
            linedefs.Add(new NLPTest.GradeLineEquation(9, (float)1.75, (float)-24.25));
            linedefs.Add(new NLPTest.GradeLineEquation(10, (float)2, (float)-35));
            linedefs.Add(new NLPTest.GradeLineEquation(11, (float)2, (float)-40));
            linedefs.Add(new NLPTest.GradeLineEquation(12, (float)2.5, (float)-58.5));
            linedefs.Add(new NLPTest.GradeLineEquation(13, (float)3.5, (float)-93));
            linedefs.Add(new NLPTest.GradeLineEquation(14, (float)5.5, (float)-163));
        }
      
        public int GetGradeLevel(float avgSylls,float avgSentences)
        {
            // first normalize the values given to cartesion positions on the graph
            float x = NormalizeX(avgSylls);
            float y = NormalizeY(avgSentences);
                       
            // given x find the first grade level equation that produces a lower y at that x
            return linedefs.Find(a => a.GetYGivenX(x) < y).GradeLevel;
        }
        private float NormalizeY(float avgSentenceCount)
        {
            float result = 0;
            int lower = -1;
            int upper = -1;
            // load the list of y axis line intervalse
            List<double> intervals = new List<double> {2.0, 2.5, 3.0, 3.3, 3.5, 3.6, 3.7, 3.8, 4.0, 4.2, 4.3, 4.5, 4.8, 5.0, 5.2, 5.6, 5.9, 6.3, 6.7, 7.1, 7.7, 8.3, 9.1, 10.0, 11.1, 12.5, 14.3, 16.7, 20.0, 25.0 };
            // find the first line lower or equal to the number we have
            lower = intervals.FindLastIndex(a => ((double)avgSentenceCount) >= a);
            // if we are not over the top or on the line grab the next higher line value
            if(lower > -1 && lower < intervals.Count-1 && ((float) intervals[lower] != avgSentenceCount))
                upper = lower + 1;
            // set the integer portion of the respons
            result = (float)lower;
            // if we have an upper limit calculate the percentage above the lower line (to two decimal places) and add it to the result
            if(upper != -1)
                 result += (float)Math.Round((((avgSentenceCount - intervals[lower])/(intervals[upper] - intervals[lower]))),2); 
            return result;
        }
        private float NormalizeX(float avgSyllableCount)
        {
            // the x axis is MUCH simpler.   Subtract 108 and divide by 2 to get the x position relative to a 0 origin.
            float result = (avgSyllableCount - 108) / 2;
            return result;
        }
    }
