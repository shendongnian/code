    using System;
    using System.Linq;
    using System.Threading.Tasks;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                int numProcessors = Environment.ProcessorCount;
                Task<long>[] results = new Task<long>[numProcessors];
                long count = 10000000000;
                long elementsPerProcessor = count / numProcessors;
                for (int i = 0; i < numProcessors; ++i)
                {
                    long end;
                    long start = i * elementsPerProcessor;
                    if (i != (numProcessors - 1))
                        end = start + elementsPerProcessor;
                    else // Last thread - go right up to the last element.
                        end = count;
                    results[i] = Task.Run(() => processElements(start, end));
                }
                long sum = results.Select(r => r.Result).Sum();
                Console.WriteLine(sum);
            }
            static long processElements(long inclusiveStart, long exclusiveEnd)
            {
                long total = 0;
                for (long i = inclusiveStart; i < exclusiveEnd; ++i)
                    if (i.ToString().Contains("14"))
                        ++total;
                return total;
            }
        }
    }
