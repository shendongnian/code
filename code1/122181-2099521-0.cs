    Rectangle _rct=null;
    Rectangle rct {
      get { return _rct; }
      set {
        throw new Exception(new System.Diagnostics.StackTrace().ToString());
        //_rct=value;
      }
    }
