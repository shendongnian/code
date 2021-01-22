          public static IEnumerable<T> MergeWith<T>(IEnumerable<T> collection1, IEnumerable<T> collection2,
                IComparer<T> comparer)
            {
                using (var enumerator1 = collection1.GetEnumerator())
                using (var enumerator2 = collection2.GetEnumerator())
                {
                    var isMoveNext1 = enumerator1.MoveNext();
                    var isMoveNext2 = enumerator2.MoveNext();
    
                    do
                    {
                        while (comparer.Compare(enumerator1.Current, enumerator2.Current) < 0 || !isMoveNext2)
                        {
                            if (isMoveNext1)
                                yield return enumerator1.Current;
                            else
                                break;
    
                            isMoveNext1 = enumerator1.MoveNext();
                        }
    
                        if (isMoveNext2)
                            yield return enumerator2.Current;
    
                        isMoveNext2 = enumerator2.MoveNext();
                    } while (isMoveNext1 || isMoveNext2);
                }
            }
