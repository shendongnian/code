class EnumerableAdapter
{
  ExternalSillyClass _target;
  public EnumerableAdapter(ExternalSillyClass target)
  {
    _target = target;
  }
  public IEnumerable<StuffInTarget> GetEnumerator(){ return _target.SomeMethodThatGivesAnEnumerator(); }
}
