    using System;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    
    namespace perftest
    {
    #if NETCOREAPP2_1
        [CoreJob]
    #else
        [ClrJob]
    #endif
        [RankColumn, MarkdownExporterAttribute.StackOverflow]
        public class Benchmark
        {
            class Comparer : IComparer<int>
            {
                public int Compare(int x, int y)
                {
                    return x > y ? 1 : x < y ? -1 : 0;
                }
            }
    
            static int ComparisonMethod(int x, int y)
            {
                return x > y ? 1 : x < y ? -1 : 0;
            }
    
            Comparison<int> _comparisonDelegate;
            IComparer<int> _comparer;
            List<int> _data, _tempData;
    
            [GlobalSetup]
            public void GlobalSetup()
            {
                var random = new Random(0);
                _comparisonDelegate = ComparisonMethod;
                _comparer = new Comparer();
                _data = Enumerable.Range(0, 1000).Select(_ => random.Next()).ToList();
                _tempData = new List<int>(_data.Count);
            }
    
            [Benchmark]
            public int Delegate()
            {
                var result = 0;
                for (var i = 0; i < _data.Count; i++)
                    result += _comparisonDelegate(_data[0], _data[i]);
                return result;
            }
    
            [Benchmark]
            public int Interface()
            {
                var result = 0;
                for (var i = 0; i < _data.Count; i++)
                    result += _comparer.Compare(_data[0], _data[i]);
                return result;
            }
    
            [Benchmark]
            public int SortUsingDelegate()
            {
                _tempData.Clear();
                _tempData.AddRange(_data);
                _tempData.Sort(_comparisonDelegate);
                return _tempData[0];
            }
    
            [Benchmark]
            public int SortUsingInterface()
            {
                _tempData.Clear();
                _tempData.AddRange(_data);
                _tempData.Sort(_comparer);
                return _tempData[0];
            }
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                BenchmarkRunner.Run<Benchmark>();
            }
        }
    }
