    {
        E e = ((C)(x)).GetEnumerator();
        try {
            while (e.MoveNext()) {
                V v = (V)(T)e.Current;
                embedded-statement
            }
        }
        finally {
            … // Dispose e
        }
    }
