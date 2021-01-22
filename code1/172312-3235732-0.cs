    using System;
    using System.Collections;
    using System.Collections.Generic;
    
    namespace TestApplication
    {
        class Program
        {
            static void Main(string[] args)
            {
                IDictionary<IEnumerable, object> dictionary1 = new Dictionary<IEnumerable, object>();
                IEnumerable key11 = new string[] { "key1", "key2" };
                IEnumerable key12 = new string[] { "key1", "key2" };
                dictionary1.Add(key11, new object());
                // Exception doesn't occur because key11 and key12 are not equal objects
                dictionary1.Add(key12, new object());
                IDictionary<KeyCollection<string>, object> dictionary2 = new Dictionary<KeyCollection<string>, object>();
                KeyCollection<string> key21 = new KeyCollection<string>(new string[] { "key1", "key2" });
                KeyCollection<string> key22 = new KeyCollection<string>(new string[] { "key1", "key2" });
                dictionary2.Add(key21, new object());
                // ArgumentEception: An item with the same key has already been added
                dictionary2.Add(key22, new object());
            }
    
            private class KeyCollection<T> : IEnumerable where T : class
            {
                private IEnumerable<T> m_KeyCollection;
    
                public KeyCollection() : this(new List<T>())
                {
                }
    
                public KeyCollection(IEnumerable<T> array)
                {
                    if (array == null)
                    {
                        throw (new NullReferenceException("'array' parameter must be initialized!"));
                    }
    
                    IList<T> list = new List<T>();
    
                    IEnumerator<T> enumerator = array.GetEnumerator();
                    while (enumerator.MoveNext())
                    {
                        list.Add(enumerator.Current);
                    }
    
                    m_KeyCollection = list;
                }
    
                public IEnumerator GetEnumerator()
                {
                    return m_KeyCollection.GetEnumerator();
                }
                
                public override bool Equals(object obj)
                {
                    KeyCollection<T> collection = (obj as KeyCollection<T>);
                    
                    if (collection == null)
                    {
                        return false;
                    }
    
                    IEnumerator<T> enumerator1 = m_KeyCollection.GetEnumerator();
                    IEnumerator enumerator2 = collection.GetEnumerator();
    
                    bool moveNext1 = false, moveNext2 = false;
                    
                    while (true)
                    {
                        moveNext1 = enumerator1.MoveNext();
                        moveNext2 = enumerator2.MoveNext();
    
                        if (moveNext1 && moveNext2)
                        {
                            T current1 = enumerator1.Current;
                            T current2 = (enumerator2.Current as T);
    
                            if ((current1 == null) || (current2 == null) || (!current1.Equals(current2)))
                            {
                                return false;
                            }
    
                            continue;
                        }
    
                        return ((!moveNext1) && (!moveNext2));
                    }
                }
    
                public override int GetHashCode()
                {
                    IEnumerator<T> enumerator = m_KeyCollection.GetEnumerator();
    
                    string stringHash = string.Empty;
                    while (enumerator.MoveNext())
                    {
                        stringHash += string.Format("_{0}", ((enumerator.Current != null) ? enumerator.Current.GetHashCode().ToString() : "-1"));
                    }
    
                    return (string.IsNullOrEmpty(stringHash) ? -1 : stringHash.GetHashCode());
                }
            }
        }
    }
