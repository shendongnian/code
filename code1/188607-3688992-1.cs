    internal class Factory<T,Arg>
    {
       Dictionary<string,Func<Arg.T>> _creators;
       public Factory(IDictionary<string,Func<Arg,T>> creators)
      {
         _creators = creators;
      }
    }
