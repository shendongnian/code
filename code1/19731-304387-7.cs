    foreach (V v in x) embedded-statement is then expanded to:
    {
        E e = ((C)(x)).GetEnumerator();
        try {
            V v;
            while (e.MoveNext()) {
                v = (V)(T)e.Current;
                embedded-statement
            }
        }
        finally {
            … // Dispose e
        }
    }
