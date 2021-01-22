    class MyClass : IDisposable
    {
      protected List<DataReader> _readers = new List<DataReader>();
      public DataReader MyFunc()
      {
          ///... code to do stuff
          _readers.Add(myReader);
          return myReader;
      }
      private void Dispose()
      {
          for (int i = _readers.Count - 1; i >= 0; i--)
          {
              DataReader dr = _reader.Remove(i);
              dr.Dispose();
          }
          _readers = null;
          // Dispose / Close Connection
      }
    }
