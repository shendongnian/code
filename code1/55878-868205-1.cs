    Public Class ResultProxy
    {
      Private Object _Obj
      Public ResultProxy(Object O)
      { _Obj = O; }
        
      Public T As<T>()
      { return (T)_Obj; }
    }
...
    Public ResultProxy getParameter("contestId")
    {
    // your method's code
       return new ResultProxy(YourPersonalFavorateReturnType);
    }
