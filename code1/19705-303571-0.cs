    class MyClass : ICloneable
    {
    public MyClass()
    {
  
    }
    public object Clone() // ICloneable implementation
    {
    MyClass mc = this.MemberwiseClone() as MyClass;
   
    return mc;
    }
  
