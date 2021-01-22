    public void FunctionThatUsesMyClass()
    {
       using(MyClass c = new MyClass())
       {
           DataReader dr = c.MyFunc();
       }
    }
