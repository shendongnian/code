    public class CastList<TTarget, TOriginal> 
      : IList<TTarget> where TOriginal : TTarget
    {
      List<TOriginal> _orig;
      public CastList(List<TOriginal> orig) { _orig = orig; }
      public Add(TTarget item) { _orig.Add(item); }
      public TTarget this[int i] 
      {
        get { return (TTarget)_orig[i]; }
        set { _orig[i] = value; }
      }
      public IEnumerator<TTarget> GetEnumerator() 
      {
         foreach(TOriginal item in _orig)
           yield return (TTarget)item;
      }
      // etc...
    }
