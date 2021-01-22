    #define OBSERVABLE_PROPERTY(propType, propName) \
    private propType _##propName; \
    public propType propName \
    { \
      get { return _##propName; } \
      set \
      { \
        if (value != _##propName) \
        { \
          _##propName = value; \
          NotifyPropertyChanged(#propName); \
        } \
      } \
    }
