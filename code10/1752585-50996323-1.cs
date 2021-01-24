    // Covariance and contravariance are only possible for
    // interface and delegate generic params
    public interface IDataMold<out T> 
    {
       T Result { get; }
    }
    
    abstract class DataMold<T> : IDataMold<T>
    {
      public abstract T Result { get; }
    }
    class StringMold : DataMold<string> {}
    class Whatever {}
    
    class WhateverMold : DataMold<Whatever> {}
