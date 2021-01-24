    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace SO
    {
        internal class Program
        {
            public static void Main(string[] args)
            {
                List<String> listA = new List<string> {"a", "b", "c", "d", "e", "f", "g"};
                List<String> listB = new List<string> {"1", "2", "3"};
    
                var mix = listA.ZipNew(listB, (l1, l2) => new[] {l1, l2}).SelectMany(x => x);
    
                foreach (var m in mix)
                {
                    Console.WriteLine(m);
                }
            }
        }
    
        public static class Impl
        {
            public static int A(this int a)
            {
                return 1;
            }
            
            public static IEnumerable<TResult> ZipNew<TFirst, TSecond, TResult>( 
                this IEnumerable<TFirst> first, 
                IEnumerable<TSecond> second, 
                Func<TFirst, TSecond, TResult> resultSelector) 
            { 
                using (IEnumerator<TFirst> iterator1 = first.GetEnumerator()) 
                using (IEnumerator<TSecond> iterator2 = second.GetEnumerator())
                {
                    var i1 = true;
                    var i2 = true;
                    var i1Shorter = false;
                    var i2Shorter = false;
                    var firstRun = true;
                    
                    
                    while(true) 
                    {
                        i1 = iterator1.MoveNext();
                        i2 = iterator2.MoveNext();
                        
                        if (!i1 && (i1Shorter || firstRun))
                        {
                            iterator1.Reset();
                            i1 = iterator1.MoveNext();
                            i1Shorter = true;
                            firstRun = false;
                        }
    
                        if (!i2 && (i2Shorter || firstRun))
                        {
                            iterator2.Reset();
                            i2 = iterator2.MoveNext();
                            i2Shorter = true;
                            firstRun = false;
                        }
    
                        if (!(i1 && i2))
                        {
                            break;
                        }
                        
                        yield return resultSelector(iterator1.Current, iterator2.Current); 
                    }
                } 
            }
        }
    }
