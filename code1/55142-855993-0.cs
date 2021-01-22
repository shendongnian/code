    Dispatcher.BeginInvoke(new DispatcherOperationCallback((param) =>
    
          {
    
               this.statusDisplay1.CallStatus = callStatusMsg;
    
              return null;
    
          }), DispatcherPriority.Background, new object[] { null });
    
        }
