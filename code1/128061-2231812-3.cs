    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SortedDictionaryAsBinaryHeap
    {
        class Program
        {
            private static Boolean _enableCompareCount = false;
            private static Int32 _compareCount = 0;
    
            static void Main(string[] args)
            {
                var rnd = new Random();
    
                for (int elementCount = 2; elementCount <= 6; elementCount++)
                {
                    var keyValues = Enumerable.Range(0, (Int32)Math.Pow(10, elementCount))
                        .Select(i => new HeapKey(Guid.NewGuid(), rnd.Next(0, 10)))
                        .ToDictionary(k => k);
                    var heap = new SortedDictionary<HeapKey, HeapKey>(keyValues);
    
                    _compareCount = 0;
                    _enableCompareCount = true;
                    var min = heap.First().Key;
                    _enableCompareCount = false;
                    Console.WriteLine("Element count: {0}; Compare count for getMinElement: {1}",
                                      (Int32)Math.Pow(10, elementCount),
                                      _compareCount);   
                    
                    _compareCount = 0;
                    _enableCompareCount = true;
                    heap.Remove(min);
                    _enableCompareCount = false;
                    Console.WriteLine("Element count: {0}; Compare count for deleteMinElement: {1}", 
                                      (Int32)Math.Pow(10, elementCount),  
                                      _compareCount);   
                }
    
                Console.ReadKey();
            }
    
            private class HeapKey : IComparable<HeapKey>
            {
                public HeapKey(Guid id, Int32 value)
                {
                    Id = id;
                    Value = value;
                }
    
                public Guid Id { get; private set; }
                public Int32 Value { get; private set; }
    
                public int CompareTo(HeapKey other)
                {
                    if (_enableCompareCount)
                    {
                        ++_compareCount;
                    }
    
                    if (other == null)
                    {
                        throw new ArgumentNullException("other");
                    }
    
                    var result = Value.CompareTo(other.Value);
    
                    return result == 0 ? Id.CompareTo(other.Id) : result;
                }
            }
        }
    }
