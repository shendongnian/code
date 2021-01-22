    static class GenStatic<T>
    {
      static void ExtMeth(this Class c) {/*...*/}
    }
    
    Class c = new Class();
    c.ExtMeth(); // Equivalent to GenStatic<T>.ExtMeth(c); what is T?
