    public class SetOnceValue<T> { 
      private T m_value;
      private bool m_isSet;
      public bool IsSet { get { return m_isSet; }}
      public T Value { get {
        if ( !IsSet ) {
           throw new InvalidOperationException("Value not set");
        }
        return m_value;
      }
      public T ValueOrDefault { get { return m_isSet ? m_value : default(T); }}
      public SetOnceValue() { }
      public void SetValue(T value) {
        if ( IsSet ) {
          throw new InvalidOperationException("Already set");
        }
        m_value = value;
        m_isSet = true;
      }
    }
