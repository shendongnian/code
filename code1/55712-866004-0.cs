    public class Foo
    {
      public int Apples { get; set; }
      public bool Banana { get; set; }
      public Bar Clementine { get; set; }
    }
    
    var myFoo = new Foo { Apples = 1, Banana = true, Clementine = new Bar() };
