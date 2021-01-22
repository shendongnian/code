    using System;
    using BenchmarkHelper;
    
    public class TrimStrings
    {
        static void Main()
        {
            Test("");
            Test(" ");
            Test(" x ");
            Test("x");
            Test(new string('x', 1000));
            Test(" " + new string('x', 1000) + " ");
            Test(new string(' ', 1000));
        }
        
        static void Test(string text)
        {
            bool expectedResult = text.Trim().Length == 0;
            string title = string.Format("Length={0}, result={1}", text.Length, 
                                         expectedResult);
            
            var results = TestSuite.Create(title, text, expectedResult)
    /*            .Add(x => x.Trim().Length == 0, "Trim().Length == 0")
                .Add(x => x.Trim() == "", "Trim() == \"\"")
                .Add(x => x.Trim().Equals(""), "Trim().Equals(\"\")")
                .Add(x => x.Trim() == string.Empty, "Trim() == string.Empty")
                .Add(x => x.Trim().Equals(string.Empty), "Trim().Equals(string.Empty)")
    */
                .Add(OriginalIsEmptyOrWhitespace)
                .Add(IsEmptyOrWhitespaceForLoop)
                .Add(IsEmptyOrWhitespaceForLoopReversed)
                .Add(IsEmptyOrWhitespaceForLoopHoistedLength)
                .RunTests()                          
                .ScaleByBest(ScalingMode.VaryDuration);
            
            results.Display(ResultColumns.NameAndDuration | ResultColumns.Score,
                            results.FindBest());
        }
     
        public static bool OriginalIsEmptyOrWhitespace(string text)
        {
            if (text.Length == 0)
            {
                return true;
            }
            foreach (char c in text)
            {
                if (c==' ' || c=='\t' || c=='\r' || c=='\n')
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    
        public static bool IsEmptyOrWhitespaceForLoop(string text)
        {
            for (int i=0; i < text.Length; i++)
            {
                char c = text[i];
                if (c==' ' || c=='\t' || c=='\r' || c=='\n')
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    
        public static bool IsEmptyOrWhitespaceForLoopReversed(string text)
        {
            for (int i=text.Length-1; i >= 0; i--)
            {
                char c = text[i];
                if (c==' ' || c=='\t' || c=='\r' || c=='\n')
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    
        public static bool IsEmptyOrWhitespaceForLoopHoistedLength(string text)
        {
            int length = text.Length;
            for (int i=0; i < length; i++)
            {
                char c = text[i];
                if (c==' ' || c=='\t' || c=='\r' || c=='\n')
                {
                    continue;
                }
                return false;
            }
            return true;
        }
    }
