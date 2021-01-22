    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Utility
    {
        public class BucketWeightedQueue<T>
        {
            private int m_MaxFallOff;
            private readonly double m_FallOffRate;
            private readonly List<List<T>> m_Buckets;
            private readonly List<int> m_FallOffFactors;
            private readonly Random m_Rand = new Random();
    
            public BucketWeightedQueue(IEnumerable<T> items, double fallOffRate )
            {
                if( fallOffRate < 0 ) 
                    throw new ArgumentOutOfRangeException("fallOffRate");
                m_MaxFallOff = 1;
                m_FallOffRate = fallOffRate;
                m_Buckets = new List<List<T>> { items.ToList() };
                m_FallOffFactors = new List<int> { m_MaxFallOff };
            }
    
            public T GetRandomItem()
            {
                var bucketIndex = GetRandomBucketIndex();
                var bucket = m_Buckets[bucketIndex];
                var itemIndex = m_Rand.Next( bucket.Count );
                var selectedItem = bucket[itemIndex];
    
                ReduceItemProbability( bucketIndex, itemIndex );
                return selectedItem;
            }
    
            private int GetRandomBucketIndex()
            {
                var randFallOffValue = m_Rand.Next( m_MaxFallOff );
                for (int i = 0; i < m_FallOffFactors.Count; i++ )
                    if( m_FallOffFactors[i] <= randFallOffValue )
                        return i;
                return m_FallOffFactors[0];
            }
    
            private void ReduceItemProbability( int bucketIndex, int itemIndex )
            {
                if( m_FallOffRate <= 0 )
                    return; // do nothing if there is no fall off rate...
                
                var item = m_Buckets[bucketIndex][itemIndex];
                m_Buckets[bucketIndex].RemoveAt( itemIndex );
    
                if( bucketIndex <= m_Buckets.Count )
                { 
                    // create a new bucket...
                    m_Buckets.Add( new List<T>() );
                    m_MaxFallOff = (int)(m_FallOffFactors[bucketIndex] / m_FallOffRate);
                    m_FallOffFactors.Add( m_MaxFallOff );
                }
    
                var nextBucket = m_Buckets[bucketIndex + 1];
                nextBucket.Add( item );
    
                if (m_Buckets[bucketIndex].Count == 0) // drop empty buckets
                    m_Buckets.RemoveAt( bucketIndex );
            }
        }
    }
