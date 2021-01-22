    SomeType obj = new SomeType();
    try {
      obj.SomeMethod(); // etc
    } finally {
      Marshal.ReleaseComObject(obj);
    }
 
