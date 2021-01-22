    using System;
    using NUnit.Framework;
    
    namespace ConsoleApplication5
    {
        class Program
        {
            // static int[] a = new int[100 * 1024 * 1024];
            static BigArray<int> a = new BigArray<int>(100 * 1024 * 1024);
    
            static void Main(string[] args)
            {
                int l = a.Length;
                for (int index = 0; index < l; index++)
                    a[index] = index;
                for (int index = 0; index < l; index++)
                    if (a[index] != index)
                        throw new InvalidOperationException();
            }
        }
    
        [TestFixture]
        public class BigArrayTests
        {
            [Test]
            public void Constructor_ZeroLength_ThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    new BigArray<int>(0);
                });
            }
    
            [Test]
            public void Constructor_NegativeLength_ThrowsArgumentOutOfRangeException()
            {
                Assert.Throws<ArgumentOutOfRangeException>(() =>
                {
                    new BigArray<int>(-1);
                });
            }
    
            [Test]
            public void Indexer_SetsAndRetrievesCorrectValues()
            {
                BigArray<int> array = new BigArray<int>(10001);
                for (int index = 0; index < array.Length; index++)
                    array[index] = index;
                for (int index = 0; index < array.Length; index++)
                    Assert.That(array[index], Is.EqualTo(index));
            }
    
            private const int PRIME_ARRAY_SIZE = 10007;
    
            [Test]
            public void Indexer_RetrieveElementJustPastEnd_ThrowsIndexOutOfRangeException()
            {
                BigArray<int> array = new BigArray<int>(PRIME_ARRAY_SIZE);
                Assert.Throws<IndexOutOfRangeException>(() =>
                {
                    array[PRIME_ARRAY_SIZE] = 0;
                });
            }
    
            [Test]
            public void Indexer_RetrieveElementJustBeforeStart_ThrowsIndexOutOfRangeException()
            {
                BigArray<int> array = new BigArray<int>(PRIME_ARRAY_SIZE);
                Assert.Throws<IndexOutOfRangeException>(() =>
                {
                    array[-1] = 0;
                });
            }
        }
    
        public class BigArray<T>
        {
            const int BUCKET_INDEX_BITS = 13;
            const int BUCKET_SIZE = 1 << BUCKET_INDEX_BITS;
            const int BUCKET_INDEX_MASK = BUCKET_SIZE - 1;
            
            private readonly T[][] _Buckets;
            private readonly int _Length;
    
            public BigArray(int length)
            {
                if (length < 1)
                    throw new ArgumentOutOfRangeException("length");
    
                _Length = length;
                int bucketCount = length >> BUCKET_INDEX_BITS;
                bool lastBucketIsFull = true;
                if ((length & BUCKET_INDEX_MASK) != 0)
                {
                    bucketCount++;
                    lastBucketIsFull = false;
                }
    
                _Buckets = new T[bucketCount][];
                for (int index = 0; index < bucketCount; index++)
                {
                    if (index < bucketCount - 1 || lastBucketIsFull)
                        _Buckets[index] = new T[BUCKET_SIZE];
                    else
                        _Buckets[index] = new T[(length & BUCKET_INDEX_MASK)];
                }
            }
    
            public int Length
            {
                get
                {
                    return _Length;
                }
            }
    
            public T this[int index]
            {
                get
                {
                    return _Buckets[index >> BUCKET_INDEX_BITS][index & BUCKET_INDEX_MASK];
                }
    
                set
                {
                    _Buckets[index >> BUCKET_INDEX_BITS][index & BUCKET_INDEX_MASK] = value;
                }
            }
        }
    }
