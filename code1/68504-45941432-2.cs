    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Running;
    public class ConcurrentVsRegularDictionary
    {
        private readonly Random _rand;
        private const int Count = 1_000;
    
        public ConcurrentVsRegularDictionary()
        {
            _rand = new Random();
        }
    
        [Benchmark]
        public void ConcurrentDictionary()
        {
            var dict = new ConcurrentDictionary<int, int>();
            Populate(dict);
    
            foreach (var key in dict.Keys)
            {
                dict[key] = _rand.Next();
            }
        }
    
        [Benchmark]
        public void Dictionary()
        {
            var dict = new Dictionary<int, int>();
            Populate(dict);
    
            foreach (var key in dict.Keys.ToArray())
            {
                dict[key] = _rand.Next();
            }
        }
    
        private void Populate(IDictionary<int, int> dictionary)
        {
            for (int i = 0; i < Count; i++)
            {
                dictionary[i] = 0;
            }
        }
    }
    
    public class Program
    {
        public static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConcurrentVsRegularDictionary>();
        }
    }
