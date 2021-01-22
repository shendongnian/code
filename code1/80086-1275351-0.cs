public DelegatingFoo : IFoo
{
  private GeneratedFoo foo;
  public DelegatingFoo(GeneratedFoo foo) { this.foo = foo; }
  public void Write(string p) { foo.Write(p); }
}
