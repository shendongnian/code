    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    namespace MyApp.Dictionaries
    {
    
        class BiDictionary<TFirst, TSecond> : IEnumerable
        {
            IDictionary<TFirst, TSecond> firstToSecond = new Dictionary<TFirst, TSecond>();
            IDictionary<TSecond, TFirst> secondToFirst = new Dictionary<TSecond, TFirst>();
    
            public void Add(TFirst first, TSecond second)
            {
                firstToSecond.Add(first, second);
                secondToFirst.Add(second, first);
            }
    
            public TSecond this[TFirst first]
            {
                get { return GetByFirst(first); }
            }
    
            public TFirst this[TSecond second]
            {
                get { return GetBySecond(second); }
            }
    
            public TSecond GetByFirst(TFirst first)
            {
                return firstToSecond[first];
            }
    
            public TFirst GetBySecond(TSecond second)
            {
                return secondToFirst[second];
            }
    
            public IEnumerator GetEnumerator()
            {
                return GetFirstEnumerator();
            }
    
            public IEnumerator GetFirstEnumerator()
            {
                return firstToSecond.GetEnumerator();
            }
    
            public IEnumerator GetSecondEnumerator()
            {
                return secondToFirst.GetEnumerator();
            }
        }
    }
