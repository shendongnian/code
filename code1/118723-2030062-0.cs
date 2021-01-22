    public YourClass
    {
       Level _level;
       public Level level 
       {
          get{ return _level;}
          set 
          {
            _level = value;
            if(_level == Level.Green) { greenControl.Enable = true; //plus disable others }
            if(_level == Level.Yellow) { yellowControl.Enable = true; //plus disable others }
            if(_level == Level.Red) { redControl.Enable = true; //plus disable others }
          }
       }
    }
