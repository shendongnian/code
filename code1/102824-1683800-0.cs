    class Foo { public int x; }
    ...
    void N() 
    {
      Foo blah = new Foo();
      blah.x = 0;
      M(blah);
    }
    ...
    void M(Foo foo)
    {
      foo.x = 123; // changes blah.x
      foo = null; // does not change blah
    }
