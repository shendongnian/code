    using System;
    using System.Diagnostics;
    
    class DigitSplitting
    {
        static void Main()        
        {
            Test(Simple);
            Test(SimpleMemo);
            Test(UnrolledMemo);
        }
        
        const int Iterations = 10000000;
        
        static void Test(Func<int, int[]> candidate)
        {
            Random rng = new Random(0);
            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < Iterations; i++)
            {
                candidate(rng.Next());
            }
            sw.Stop();
            Console.WriteLine("{0}: {1}",
                candidate.Method.Name, (int) sw.ElapsedMilliseconds);            
        }
        
        #region Simple
        static int[] Simple(int value)
        {
            int size = DetermineDigitCount(value);
            int[] digits = new int[size];
            for (int index = size - 1; index >= 0; index--)
            {
                digits[index] = value % 10;
                value = value / 10;
            }
            return digits;
        }
        
        private static int DetermineDigitCount(int x)
        {
            // This bit could be optimised with a binary search
            return x < 10 ? 1
                 : x < 100 ? 2
                 : x < 1000 ? 3
                 : x < 10000 ? 4
                 : x < 100000 ? 5
                 : x < 1000000 ? 6
                 : x < 10000000 ? 7
                 : x < 100000000 ? 8
                 : x < 1000000000 ? 9
                 : 10;
        }
        #endregion Simple    
        
        #region SimpleMemo
        private static readonly int[][] memoizedResults = new int[10000][];
    
        public static int[] SimpleMemo(int value)
        {
            if (value < 10000)
            {
                int[] memoized = memoizedResults[value];
                if (memoized == null) {
                    memoized = ConvertSmall(value);
                    memoizedResults[value] = memoized;
                }
                return (int[]) memoized.Clone();
            }
            // We know that value >= 10000
            int size = value >= 1000000000 ? 10
                     : value >= 100000000 ? 9
                     : value >= 10000000 ? 8
                     : value >= 1000000 ? 7
                     : value >= 100000 ? 6
                     : 5;
        
            return ConvertWithSize(value, size);
        }
        
        private static int[] ConvertSmall(int value)
        {
            // We know that value < 10000
            return value >= 1000 ? new[] { value / 1000, (value / 100) % 10,
                                               (value / 10) % 10, value % 10 }
                  : value >= 100 ? new[] { value / 100, (value / 10) % 10, 
                                             value % 10 }
                  : value >= 10 ? new[] { value / 10, value % 10 }
                  : new int[] { value };
        }
        
        private static int[] ConvertWithSize(int value, int size)
        {
            int[] digits = new int[size];
            for (int index = size - 1; index >= 0; index--)
            {
                digits[index] = value % 10;
                value = value / 10;
            }
            return digits;
        }
        #endregion
        
        #region UnrolledMemo
        private static readonly int[][] memoizedResults2 = new int[10000][];
        private static readonly int[][] memoizedResults3 = new int[10000][];
        static int[] UnrolledMemo(int value)
        {
            if (value < 10000)
            {
                return (int[]) UnclonedConvertSmall(value).Clone();
            }
            if (value >= 1000000000)
            {
                int[] ret = new int[10];
                int firstChunk = value / 100000000;
                ret[0] = firstChunk / 10;
                ret[1] = firstChunk % 10;
                value -= firstChunk * 100000000;
                int[] secondChunk = ConvertSize4(value / 10000);
                int[] thirdChunk = ConvertSize4(value % 10000);
                ret[2] = secondChunk[0];
                ret[3] = secondChunk[1];
                ret[4] = secondChunk[2];
                ret[5] = secondChunk[3];
                ret[6] = thirdChunk[0];
                ret[7] = thirdChunk[1];
                ret[8] = thirdChunk[2];
                ret[9] = thirdChunk[3];
                return ret;
            } 
            else if (value >= 100000000)
            {
                int[] ret = new int[9];
                int firstChunk = value / 100000000;
                ret[0] = firstChunk;
                value -= firstChunk * 100000000;
                int[] secondChunk = ConvertSize4(value / 10000);
                int[] thirdChunk = ConvertSize4(value % 10000);
                ret[1] = secondChunk[0];
                ret[2] = secondChunk[1];
                ret[3] = secondChunk[2];
                ret[4] = secondChunk[3];
                ret[5] = thirdChunk[0];
                ret[6] = thirdChunk[1];
                ret[7] = thirdChunk[2];
                ret[8] = thirdChunk[3];
                return ret;
            }
            else if (value >= 10000000)
            {
                int[] ret = new int[8];
                int[] firstChunk = ConvertSize4(value / 10000);
                int[] secondChunk = ConvertSize4(value % 10000);
                ret[0] = firstChunk[0];
                ret[1] = firstChunk[0];
                ret[2] = firstChunk[0];
                ret[3] = firstChunk[0];
                ret[4] = secondChunk[0];
                ret[5] = secondChunk[1];
                ret[6] = secondChunk[2];
                ret[7] = secondChunk[3];
                return ret;
            }
            else if (value >= 1000000)
            {
                int[] ret = new int[7];
                int[] firstChunk = ConvertSize4(value / 10000);
                int[] secondChunk = ConvertSize4(value % 10000);
                ret[0] = firstChunk[1];
                ret[1] = firstChunk[2];
                ret[2] = firstChunk[3];
                ret[3] = secondChunk[0];
                ret[4] = secondChunk[1];
                ret[5] = secondChunk[2];
                ret[6] = secondChunk[3];
                return ret;
            }
            else if (value >= 100000)
            {
                int[] ret = new int[6];
                int[] firstChunk = ConvertSize4(value / 10000);
                int[] secondChunk = ConvertSize4(value % 10000);
                ret[0] = firstChunk[2];
                ret[1] = firstChunk[3];
                ret[2] = secondChunk[0];
                ret[3] = secondChunk[1];
                ret[4] = secondChunk[2];
                ret[5] = secondChunk[3];
                return ret;
            }
            else
            {
                int[] ret = new int[5];
                int[] chunk = ConvertSize4(value % 10000);
                ret[0] = value / 10000;
                ret[1] = chunk[0];
                ret[2] = chunk[1];
                ret[3] = chunk[2];
                ret[4] = chunk[3];
                return ret;
            }
        }
        
        private static int[] UnclonedConvertSmall(int value)
        {
            int[] ret = memoizedResults2[value];
            if (ret == null)
            {
                ret = value >= 1000 ? new[] { value / 1000, (value / 100) % 10,
                                               (value / 10) % 10, value % 10 }
                  : value >= 100 ? new[] { value / 100, (value / 10) % 10, 
                                             value % 10 }
                  : value >= 10 ? new[] { value / 10, value % 10 }
                  : new int[] { value };
                memoizedResults2[value] = ret;
            }
            return ret;
        }
        
        private static int[] ConvertSize4(int value)
        {
            int[] ret = memoizedResults3[value];
            if (ret == null)
            {
                ret = new[] { value / 1000, (value / 100) % 10,
                             (value / 10) % 10, value % 10 };
                memoizedResults3[value] = ret;
            }
            return ret;
        }
        #endregion UnrolledMemo
    }
