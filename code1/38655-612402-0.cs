    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    public class ArraySegmentConcatenator<T> : IEnumerable<T>
    {
        private readonly List<ArraySegment<T>> segments =
            new List<ArraySegment<T>>();
        
        public IEnumerator<T> GetEnumerator()
        {
            foreach (ArraySegment<T> segment in segments)
            {
                for (int i=0; i < segment.Count; i++)
                {
                    yield return segment.Array[i+segment.Offset];
                }
            }
        }
        
        public void Add(ArraySegment<T> segment)
        {
            segments.Add(segment);
        }
        
        public void Add(T[] array)
        {
            segments.Add(new ArraySegment<T>(array));
        }
    
        public void Add(T[] array, int count)
        {
            segments.Add(new ArraySegment<T>(array, 0, count));
        }
    
        public void Add(T[] array, int offset, int count)
        {
            segments.Add(new ArraySegment<T>(array, offset, count));
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
