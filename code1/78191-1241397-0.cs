    //Example 1  
    class SomeClass<T> where T : class
    {
      public void SomeMethod<TProperty>(Expression<Func<T,TProperty>> expression) {}
    }
