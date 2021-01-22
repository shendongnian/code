    public static class Switch {
      public static SwitchBuilder<TElement>.CaseBuilder On<TElement>(TElement element) {
        return new SwitchBuilder<TElement>(element).Start();
      }
      public class SwitchBuilder<TElement> {
        TElement _element;
        TElement _firstCase;
        internal SwitchBuilder(TElement element) { _element = element; }
        internal CaseBuilder Start() {
          return new CaseBuilder() { Switch = this };
        }
        private ThenBuilder Case(TElement element) {
          _firstCase = element;
          return new ThenBuilder() { Switch = this };
        }
        private SwitchBuilder<TElement, TResult>.CaseBuilder Then<TResult>(TResult result) {
          return new SwitchBuilder<TElement, TResult>(
            _element,
            _firstCase,
            result).Start();
        }
        public class CaseBuilder {
          internal SwitchBuilder<TElement> Switch { get; set; }
          public ThenBuilder Case(TElement element) {
            return Switch.Case(element);
          }
        }
        public class ThenBuilder {
          internal SwitchBuilder<TElement> Switch { get; set; }
          public SwitchBuilder<TElement, TResult>.CaseBuilder Then<TResult>(TResult result) {
            return Switch.Then(result);
          }
        }
      }
      public class SwitchBuilder<TElement, TResult> {
        TElement _element;
        TElement _currentCase;
        IDictionary<TElement, TResult> _map = new Dictionary<TElement, TResult>();
        internal SwitchBuilder(TElement element, TElement firstCase, TResult firstResult) {
          _element = element;
          _map.Add(firstCase, firstResult);
        }
        internal CaseBuilder Start() {
          return new CaseBuilder() { Switch = this };
        }
        private ThenBuilder Case(TElement element) {
          _currentCase = element;
          return new ThenBuilder() { Switch = this };
        }
        private CaseBuilder Then(TResult result) {
          _map.Add(_currentCase, result);
          return new CaseBuilder() { Switch = this };
        }
        private TResult Default(TResult defaultResult) {
          TResult result;
          if (_map.TryGetValue(_element, out result)) {
            return result;
          }
          return defaultResult;
        }
        public class CaseBuilder {
          internal SwitchBuilder<TElement, TResult> Switch { get; set; }
          public ThenBuilder Case(TElement element) {
            return Switch.Case(element);
          }
          public TResult Default(TResult defaultResult) {
            return Switch.Default(defaultResult);
          }
        }
        public class ThenBuilder {
          internal SwitchBuilder<TElement, TResult> Switch { get; set; }
          public CaseBuilder Then(TResult result) {
            return Switch.Then(result);
          }
        }
      }
    }
