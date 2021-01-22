    public class Switch<TElement, TResult> {
      TElement _element;
      TElement _currentCase;
      IDictionary<TElement, TResult> _map = new Dictionary<TElement, TResult>();
      public Switch(TElement element) { _element = element; }
      public Switch<TElement, TResult> Case(TElement element) {
        _currentCase = element;
        return this;
      }
      public Switch<TElement, TResult> Then(TResult result) {
        _map.Add(_currentCase, result);
        return this;
      }
      public TResult Default(TResult defaultResult) {
        TResult result;
        if (_map.TryGetValue(_element, out result)) {
          return result;
        }
        return defaultResult;
      }
    }
