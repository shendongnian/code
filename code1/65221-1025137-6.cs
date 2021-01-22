    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    
    namespace ConsoleApplication21 {
    
        static class LinqExtensions {
    
            public static IEnumerable<T> GetIndexedItemsEric<T>(this IEnumerable<T> collection, IEnumerable<int> indices) {
                int currentIndex = -1;
                using (var collectionEnum = collection.GetEnumerator()) {
                    foreach (int index in indices) {
                        while (collectionEnum.MoveNext()) {
                            currentIndex += 1;
                            if (currentIndex == index) {
                                yield return collectionEnum.Current;
                                break;
                            }
                        }
                    }
                }
            }
    
            public static IEnumerable<T> GetIndexedItemsSam<T>(this IEnumerable<T> collection, IEnumerable<int> indices) {
                var rest = collection.GetEnumerator();
                foreach (int offset in indices.Distances()) {
                    Skip(rest, offset);
                    yield return rest.Current;
                }
            }
    
            static void Skip<T>(this IEnumerator<T> enumerator, int skip) {
                while (skip > 0) {
                    enumerator.MoveNext();
                    skip--;
                }
                return;
            }
    
            static IEnumerable<int> Distances(this IEnumerable<int> numbers) {
                int offset = 0;
                foreach (var number in numbers) {
                    yield return number - offset;
                    offset = number;
                }
            }
        } 
    
        class Program {
    
            static void TimeAction(string description, int iterations, Action func) {
                var watch = new Stopwatch();
                watch.Start();
                for (int i = 0; i < iterations; i++) {
                    func(); 
                }
                watch.Stop();
                Console.Write(description);
                Console.WriteLine(" Time Elapsed {0} ms", watch.ElapsedMilliseconds);
            }
    
            static void Main(string[] args) {
    
                int max = 100000;
                int lookupCount = 1000;
                int iterations = 500;
                var rand = new Random();
                var array = Enumerable.Range(0, max).ToArray();
                var lookups = Enumerable.Range(0, lookupCount).Select(i => rand.Next(max - 1)).Distinct().OrderBy(_ => _).ToArray();
    
                // warmup 
                array.GetIndexedItemsEric(lookups).ToArray();
                array.GetIndexedItemsSam(lookups).ToArray();
    
                TimeAction("Eric's Solution", iterations, () => {
                    array.GetIndexedItemsEric(lookups).ToArray();
                });
    
                TimeAction("Sam's Solution", iterations, () =>
                {
                    array.GetIndexedItemsEric(lookups).ToArray();
                });
    
                Console.ReadKey();
            }
        }
    }
Eric's Solution Time Elapsed 770 ms
Sam's Solution Time Elapsed 768 ms
