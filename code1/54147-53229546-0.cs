        private Cursor _CursorType;
        // Property to set and get the cursor type
        public Cursor CursorType
        {
          get {return _CursorType; }
          set
          {
            _CursorType = value;
            OnPropertyChanged("CursorType");
          }
        }
        private void ExecutedMethodOnButtonPress()
        {
           try
           {
             CursorType = Cursors.Wait;
             // Run all other code here
           }
           finally
           {
             CursorType = Cursors.Arrow;
           }
        }
