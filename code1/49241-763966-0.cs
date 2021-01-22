    public static int GetHashCodeFromFields<T1,T2,T3,T4>(this object obj, T1 obj1, T2 obj2, T3 obj3, T4 obj4) {
        int hashCode = _seedPrimeNumber;
        if(obj1 != null)
            hashCode *= _fieldPrimeNumber + obj1.GetHashCode();
        if(obj2 != null)
            hashCode *= _fieldPrimeNumber + obj2.GetHashCode();
        if(obj3 != null)
            hashCode *= _fieldPrimeNumber + obj3.GetHashCode();
        if(obj4 != null)
            hashCode *= _fieldPrimeNumber + obj4.GetHashCode();
        return hashCode;
    }
