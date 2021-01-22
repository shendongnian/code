        using System.Numerics;
        private static ulong SumSseInner(this uint[] arrayToSum, int l, int r)
        {
            var sumVectorLower = new Vector<ulong>();
            var sumVectorUpper = new Vector<ulong>();
            var longLower      = new Vector<ulong>();
            var longUpper      = new Vector<ulong>();
            int sseIndexEnd = l + ((r - l + 1) / Vector<uint>.Count) * Vector<uint>.Count;
            int i;
            for (i = l; i < sseIndexEnd; i += Vector<int>.Count)
            {
                var inVector = new Vector<uint>(arrayToSum, i);
                Vector.Widen(inVector, out longLower, out longUpper);
                sumVectorLower += longLower;
                sumVectorUpper += longUpper;
            }
            ulong overallSum = 0;
            for (; i <= r; i++)
                overallSum += arrayToSum[i];
            sumVectorLower += sumVectorUpper;
            for (i = 0; i < Vector<long>.Count; i++)
                overallSum += sumVectorLower[i];
            return overallSum;
        }
