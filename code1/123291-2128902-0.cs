    IContainer c = new Container();
    c.Configure(ce=>
      ce.For(typeof(A)).Use(typeof(A)).WithProperty("Test").EqualTo("Hello"));
    var a = c.GetInstance<A>();
    Debug.Assert(a.Test == "Hello");
