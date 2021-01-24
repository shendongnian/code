    interface ICopy<T>
    {
      void Copy<T>(T t)
    }
    Class A: ICopy<A>,BaseClass//(if you need baseclass)
    {
      public void Copy(A a)
      {}
    }
    Class B: ICopy<B>,BaseClass//(if you need baseclass)
    {
      public void Copy(B b)
      {}
    }
