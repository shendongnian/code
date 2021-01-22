     { return _WorkingScreen; }
          set
            {
                if (WorkingScreen != value)
                {
                    _WorkingScreen = value;
                    OnWorkingScreenChanged();
                }
            }
        }
