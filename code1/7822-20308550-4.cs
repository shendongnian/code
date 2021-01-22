    var enumerator = new Test().GetEnumerator();
    try {
       Something element; //pre C# 5
       while (enumerator.MoveNext()) {
          Something element; //post C# 5
          element = (Something)enumerator.Current; //the cast!
          statement;
       }
    }
    finally {
       IDisposable disposable = enumerator as System.IDisposable;
       if (disposable != null) disposable.Dispose();
    }
