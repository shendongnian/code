    public class A { public int Data { get; set; } }
    
    public void SomeFunction(A a)
    {
        a.Data *= 2;
    }
    var listy = new List<A>() { 
        new A() { Data = 3 }, 
        new A() { Data = 5 } 
    };
    listy.Select(x => { SomeFunction(x); return x; })
