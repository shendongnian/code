    class C<T>
    {
      public virtual void M<U>(T t, U u) where U : T { }
    }
    class D : C<int>
    {
      public override void M<U>(int t, U u)
      {
