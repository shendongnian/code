    // Wrong
    if ( o is SomeType ) {
      SomeType st = (SomeType)o;
      st.TakeSomeAction();
    }
    
    // Right
    SomeType st = o as SomeType;
    if ( st != null ) {
      st.TakeSomeAction();
    }
