        public EventHandlerClassConstructor()
        {
                EventHolderCallingClass.HandleExceptionEvent += new EventHolderCallingClass.HandleExceptionEventDelegate(HandleExceptionEventHandler);            
        }
        void HandleExceptionEventHandler(Exception exception)
        {
            //handle exception here.
        }
