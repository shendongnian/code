     public CopyCommand Copy
     {
         get
         {
              if (_copy == null)
              {
                 _copy = new CopyCommand(this);
              }
           return _copy;
          }
