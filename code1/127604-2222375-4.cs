    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication20
    {
        class SectionEnumerable<T> : IEnumerable<T>
        {
            private readonly IEnumerator<T> _Enumerator;
    
            public SectionEnumerable(IEnumerator<T> enumerator, int sectionSize)
            {
                _Enumerator = enumerator;
                Left = sectionSize;
            }
    
            public IEnumerator<T> GetEnumerator()
            {
                while (Left > 0)
                {
                    Left--;
                    yield return _Enumerator.Current;
                    if (Left > 0)
                        if (!_Enumerator.MoveNext())
                            break;
                }
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
    
            public int Left { get; private set; }
        }
    
        static class SequenceExtensions
        {
            public static IEnumerable<IEnumerable<T>> Section<T>(this IEnumerable<T> collection, int sectionSize)
            {
                if (collection == null)
                    throw new ArgumentNullException("collection");
                if (sectionSize < 1)
                    throw new ArgumentOutOfRangeException("sectionSize");
    
                using (IEnumerator<T> enumerator = collection.GetEnumerator())
                {
                    while (enumerator.MoveNext())
                    {
                        SectionEnumerable<T> enumerable = new SectionEnumerable<T>(enumerator, sectionSize);
                        yield return enumerable;
                        for (int index = 0; index < enumerable.Left; index++)
                            if (!enumerator.MoveNext())
                                yield break;
                    }
                }
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var sequence = Enumerable.Range(0, 100);
                var sections = sequence.Section(10);
                foreach (var section in sections)
                {
                    Console.WriteLine(
                        String.Join(", ",
                        section.Take(5).ToArray().Select(i => i.ToString()).ToArray()));
                }
                Console.ReadLine();
            }
        }
    }
