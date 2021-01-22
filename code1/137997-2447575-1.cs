    IEnumerable<string> enumerator = (collection).GetEnumerator();
    try {
       while (enumerator.MoveNext()) {
          string part = (string)enumerator.Current;
          // Do Something or other. 
       }
    } finally {
       IDisposable disposable = enumerator as System.IDisposable;
       if (disposable != null) disposable.Dispose();
    }
