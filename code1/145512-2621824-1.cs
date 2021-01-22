    static class NonGenStatic
    {
      static void GenExtMeth<T>(this Class c) {/*...*/}
    }
    
    Class c = newClass();
    c.ExtMeth<Class2>(); // Equivalent to NonGenStatic.ExtMeth<Class2>(c); OK
