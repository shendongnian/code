    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace RandomElements
    {
        class Program
        {
            static IEnumerable<int> GetRandomElements(IEnumerable<int> source, int count)
            {
                var random = new Random();
                var length = source.Count();
                var enumerator = source.GetEnumerator();
    
                if (length < count)
                {
                    throw new InvalidOperationException("Seriously?");
                }
    
                while (count > 0)
                {
                    const int bias = 5;
                    var next = random.Next((length / bias) - count - bias) + 1; // To make sure we don't starve.
                    length -= next;
    
                    while (next > 0)
                    {
                        if (!enumerator.MoveNext())
                        {
                            throw new InvalidOperationException("What, we starved out?");
                        }
    
                        --next;
                    }
    
                    yield return enumerator.Current;
    
                    --count;
                }
            }
    
            static void Main(string[] args)
            {
                var sequence = Enumerable.Range(1, 100);
                var random = GetRandomElements(sequence, 10);
    
                random.ToList().ForEach(Console.WriteLine);
            }
        }
    }
