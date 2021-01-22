    namespace CoreLib.Helpers
    {
        using System;
        using System.Security.Cryptography;
    
        public static class Rnd
        {
            private static readonly Random _random = new Random();
    
            public static Random Generator { get { return _random; } }
    
            static Rnd()
            {
            }
    
            public static class Crypto
            {
                private static readonly RandomNumberGenerator _highRandom = RandomNumberGenerator.Create();
    
                public static RandomNumberGenerator Generator { get { return _highRandom; } }
    
                static Crypto()
                {
                }
    
            }
    
            public static UInt32 Next(this RandomNumberGenerator value)
            {
                var bytes = new byte[4];
                value.GetBytes(bytes);
    
                return BitConverter.ToUInt32(bytes, 0);
            }
        }
    }
    
    [TestMethod]
    public void Rnd_OnGenerator_UniqueRandomSequence()
    {
        var rdn1 = Rnd.Generator;
        var rdn2 = Rnd.Generator;
        var list = new List<Int32>();
        var tasks = new Task[10];
        for (var i = 0; i < 10; i++)
        {
            tasks[i] = Task.Factory.StartNew((() =>
            {
                for (var k = 0; k < 1000; k++)
                {
                    lock (list)
                    {
                        list.Add(Rnd.Generator.Next(Int32.MinValue, Int32.MaxValue));
                    }
                }
            }));
        }
        Task.WaitAll(tasks);
        var distinct = list.Distinct().ToList();
        Assert.AreSame(rdn1, rdn2);
        Assert.AreEqual(10000, list.Count);
        Assert.AreEqual(list.Count, distinct.Count);
    }
    
    [TestMethod]
    public void Rnd_OnCryptoGenerator_UniqueRandomSequence()
    {
        var rdn1 = Rnd.Crypto.Generator;
        var rdn2 = Rnd.Crypto.Generator;
        var list = new ConcurrentQueue<UInt32>();
        var tasks = new Task[10];
        for (var i = 0; i < 10; i++)
        {
            tasks[i] = Task.Factory.StartNew((() =>
            {
                for (var k = 0; k < 1000; k++)
                {
                        list.Enqueue(Rnd.Crypto.Generator.Next());
                }
            }));
        }
        Task.WaitAll(tasks);
        var distinct = list.Distinct().ToList();
        Assert.AreSame(rdn1, rdn2);
        Assert.AreEqual(10000, list.Count);
        Assert.AreEqual(list.Count, distinct.Count);
    }
