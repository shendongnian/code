    public int MemCmp<TEn>(TEn obj1, TEn obj2) where TEn : IEnumerable 
    {
        IEnumerator enumerator1 = obj1.GetEnumerator();
        IEnumerator enumerator2 = obj2.GetEnumerator();
        bool has1Next;
        bool has2Next;
        do
        {
            has1Next = enumerator1.MoveNext();
            has2Next = enumerator2.MoveNext();
            if(has1Next && has2Next)
            {
                if (enumerator1.Current is IComparable)
                {
                    int comparison = ((IComparable) enumerator1.Current).CompareTo(enumerator2.Current);
                    if (comparison != 0) return (comparison > 0) ? 1 : -1;
                }
                else if (enumerator2.Current is IComparable)
                {
                    int comparison = ((IComparable) enumerator2.Current).CompareTo(enumerator1.Current);
                    if (comparison != 0) return (comparison > 0) ? -1 : 1;
                }
                else
                {
                    throw new ArgumentException("Not comparable types");
                }
            }
            else 
            {
                if(has1Next)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        } while (true);
    }
