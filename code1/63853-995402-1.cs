    protected void Invoke(Action<MyService> action) {
       using(MyService svc = new MyService()) {
         try {
           action(svc);
         } catch {...} // your long boilerplate code
       }
    }
    ...
    public void MyServiceCall(string stringArg, bool boolArg, int intArg)
    {
        Invoke(svc => svc.MyServiceCall(stringArg, boolArg, intArg));
    }
