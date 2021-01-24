    // This is not at all idiomatic C#, please don't use this as an example
    public struct MutableStruct
    {
          private string _someVal;
          public MutableStruct(string someVal)
          {
              _someVal = someVal;
          }
          public void GetVal()
          {
              return _someVal
          }
          public void Mutate(string newVal)
          {
              _someVal = newVal;
          }
    }
