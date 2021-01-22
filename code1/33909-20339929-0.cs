    interface IGenericAction { bool Act<T>(); }
    struct Blah<T>
    {
      public static void ActUpon(IGenericAction action)
      {
         if (action.Act<T>())
           Blah<Blah<T>>.ActUpon(action);
      }
    }
