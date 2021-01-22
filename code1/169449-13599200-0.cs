        public bool IsEnabled
        {
           get
           {
               return _isEnabled;
           }
           set
           {
               lock (_instanceLock)
               {
                   if (!value && _isEnabled)
                   {
                       Stop();
                   }
                   else
                   {
                       if (!value || _isEnabled)
                           return;
                       Start();
                   }
               }
           }
        }
