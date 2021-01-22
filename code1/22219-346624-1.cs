    struct Value
    {
      int _accuracyPlusOne;
      public int Accuracy
      { 
        get { return _accuracyPlusOne - 1; }
        get { _accuracyPlusOne= value + 1; }
      }
    }
