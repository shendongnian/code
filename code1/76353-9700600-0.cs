    class Derp : interfaceX
    {
       int somevalue=0; //specified that this class contains somevalue by interfaceX
       public Derp(int val)
        {
        somevalue = val;
        }
    }
    void Foo(ref object obj){
        int result = (interfaceX)obj.somevalue;
        //do stuff to result variable... in my case data access
        obj = Activator.CreateInstance(obj.GetType(), result);
    }
    main()
    {
       Derp x = new Derp();
       Foo(ref Derp);
    }
