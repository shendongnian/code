    using System;
    using System.Threading.Tasks;
    
    namespace PrimeGenerator
    {
        public static class CompartmentalisedParallel
        {
            #region Int
    
            private static int[] CalculateCompartments(int startInclusive, int endExclusive, ref int threads)
            {
                if (threads == 0) threads = 1;
                if (threads == -1) threads = Environment.ProcessorCount;
                if (threads > endExclusive - startInclusive) threads = endExclusive - startInclusive;
    
                int[] liThreadIndexes = new int[threads + 1];
                liThreadIndexes[threads] = endExclusive - 1;
                int liIndexesPerThread = (endExclusive - startInclusive) / threads;
                for (int liCount = 0; liCount < threads; liCount++)
                    liThreadIndexes[liCount] = liCount * liIndexesPerThread;
    
                return liThreadIndexes;
            }
    
            public static void For<TLocal>(
                int startInclusive, int endExclusive,
                ParallelOptions parallelOptions,
                Func<int, int, TLocal> localInit,
                Func<int, ParallelLoopState, TLocal, TLocal> body,
                Action<TLocal, int, int> localFinally,
                int threads)
            {
                int[] liThreadIndexes = CalculateCompartments(startInclusive, endExclusive, ref threads);
    
                if (threads > 1)
                    Parallel.For(
                        0, threads, parallelOptions,
                        (liThread, lsState) =>
                        {
                            TLocal llLocal = localInit(liThreadIndexes[liThread], liThreadIndexes[liThread + 1]);
    
                            for (int liCounter = liThreadIndexes[liThread]; liCounter < liThreadIndexes[liThread + 1]; liCounter++)
                                body(liCounter, lsState, llLocal);
    
                            localFinally(llLocal, liThreadIndexes[liThread], liThreadIndexes[liThread + 1]);
                        }
                    );
                else
                {
                    TLocal llLocal = localInit(startInclusive, endExclusive);
                    for (int liCounter = startInclusive; liCounter < endExclusive; liCounter++)
                        body(liCounter, null, llLocal);
                    localFinally(llLocal, startInclusive, endExclusive);
                }
            }
    
            public static void For(
                int startInclusive, int endExclusive,
                ParallelOptions parallelOptions,
                Action<int, ParallelLoopState> body,
                int threads)
            {
                int[] liThreadIndexes = CalculateCompartments(startInclusive, endExclusive, ref threads);
    
                if (threads > 1)
                    Parallel.For(
                        0, threads, parallelOptions,
                        (liThread, lsState) =>
                        {
                            for (int liCounter = liThreadIndexes[liThread]; liCounter < liThreadIndexes[liThread + 1]; liCounter++)
                                body(liCounter, lsState);
                        }
                    );
                else
                    for (int liCounter = startInclusive; liCounter < endExclusive; liCounter++)
                        body(liCounter, null);
            }
    
            public static void For(
                int startInclusive, int endExclusive,
                ParallelOptions parallelOptions,
                Action<int> body,
                int threads)
            {
                int[] liThreadIndexes = CalculateCompartments(startInclusive, endExclusive, ref threads);
    
                if (threads > 1)
                    Parallel.For(
                        0, threads, parallelOptions,
                        (liThread) =>
                        {
                            for (int liCounter = liThreadIndexes[liThread]; liCounter < liThreadIndexes[liThread + 1]; liCounter++)
                                body(liCounter);
                        }
                    );
                else
                    for (int liCounter = startInclusive; liCounter < endExclusive; liCounter++)
                        body(liCounter);
            }
    
            public static void For(
                int startInclusive, int endExclusive,
                Action<int, ParallelLoopState> body,
                int threads)
            {
                For(startInclusive, endExclusive, new ParallelOptions(), body, threads);
            }
    
            public static void For(
                int startInclusive, int endExclusive,
                Action<int> body,
                int threads)
            {
                For(startInclusive, endExclusive, new ParallelOptions(), body, threads);
            }
    
            public static void For<TLocal>(
                int startInclusive, int endExclusive,
                Func<int, int, TLocal> localInit,
                Func<int, ParallelLoopState, TLocal, TLocal> body,
                Action<TLocal, int, int> localFinally,
                int threads)
            {
                For<TLocal>(startInclusive, endExclusive, new ParallelOptions(), localInit, body, localFinally, threads);
            }
    
            #endregion
    
            #region Long
    
            private static long[] CalculateCompartments(long startInclusive, long endExclusive, ref long threads)
            {
                if (threads == 0) threads = 1;
                if (threads == -1) threads = Environment.ProcessorCount;
                if (threads > endExclusive - startInclusive) threads = endExclusive - startInclusive;
    
                long[] liThreadIndexes = new long[threads + 1];
                liThreadIndexes[threads] = endExclusive - 1;
                long liIndexesPerThread = (endExclusive - startInclusive) / threads;
                for (long liCount = 0; liCount < threads; liCount++)
                    liThreadIndexes[liCount] = liCount * liIndexesPerThread;
    
                return liThreadIndexes;
            }
    
            public static void For<TLocal>(
                long startInclusive, long endExclusive,
                ParallelOptions parallelOptions,
                Func<long, long, TLocal> localInit,
                Func<long, ParallelLoopState, TLocal, TLocal> body,
                Action<TLocal, long, long> localFinally,
                long threads)
            {
                long[] liThreadIndexes = CalculateCompartments(startInclusive, endExclusive, ref threads);
    
                if (threads > 1)
                    Parallel.For(
                        0, threads, parallelOptions,
                        (liThread, lsState) =>
                        {
                            TLocal llLocal = localInit(liThreadIndexes[liThread], liThreadIndexes[liThread + 1]);
    
                            for (long liCounter = liThreadIndexes[liThread]; liCounter < liThreadIndexes[liThread + 1]; liCounter++)
                                body(liCounter, lsState, llLocal);
    
                            localFinally(llLocal, liThreadIndexes[liThread], liThreadIndexes[liThread + 1]);
                        }
                    );
                else
                {
                    TLocal llLocal = localInit(startInclusive, endExclusive);
                    for (long liCounter = startInclusive; liCounter < endExclusive; liCounter++)
                        body(liCounter, null, llLocal);
                    localFinally(llLocal, startInclusive, endExclusive);
                }
            }
    
            public static void For(
                long startInclusive, long endExclusive,
                ParallelOptions parallelOptions,
                Action<long, ParallelLoopState> body,
                long threads)
            {
                long[] liThreadIndexes = CalculateCompartments(startInclusive, endExclusive, ref threads);
    
                if (threads > 1)
                    Parallel.For(
                        0, threads, parallelOptions,
                        (liThread, lsState) =>
                        {
                            for (long liCounter = liThreadIndexes[liThread]; liCounter < liThreadIndexes[liThread + 1]; liCounter++)
                                body(liCounter, lsState);
                        }
                    );
                else
                    for (long liCounter = startInclusive; liCounter < endExclusive; liCounter++)
                        body(liCounter, null);
            }
    
            public static void For(
                long startInclusive, long endExclusive,
                ParallelOptions parallelOptions,
                Action<long> body,
                long threads)
            {
                long[] liThreadIndexes = CalculateCompartments(startInclusive, endExclusive, ref threads);
    
                if (threads > 1)
                    Parallel.For(
                        0, threads, parallelOptions,
                        (liThread) =>
                        {
                            for (long liCounter = liThreadIndexes[liThread]; liCounter < liThreadIndexes[liThread + 1]; liCounter++)
                                body(liCounter);
                        }
                    );
                else
                    for (long liCounter = startInclusive; liCounter < endExclusive; liCounter++)
                        body(liCounter);
            }
    
            public static void For(
                long startInclusive, long endExclusive,
                Action<long, ParallelLoopState> body,
                long threads)
            {
                For(startInclusive, endExclusive, new ParallelOptions(), body, threads);
            }
    
            public static void For(
                long startInclusive, long endExclusive,
                Action<long> body,
                long threads)
            {
                For(startInclusive, endExclusive, new ParallelOptions(), body, threads);
            }
    
            public static void For<TLocal>(
                long startInclusive, long endExclusive,
                Func<long, long, TLocal> localInit,
                Func<long, ParallelLoopState, TLocal, TLocal> body,
                Action<TLocal, long, long> localFinally,
                long threads)
            {
                For<TLocal>(startInclusive, endExclusive, new ParallelOptions(), localInit, body, localFinally, threads);
            }
    
            #endregion
        }
    }
