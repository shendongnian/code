    class SomeClass : ISomeInterface
    {
      protected object ExecuteCommand(SvcCmdType cmdType, params object[] inputParams)
      {
        lock(executeCommandLock)
        {
          SvcCommandEventArgs eventArgs = new SvcCommandEventArgs(cmdType, inputParams);
          OnProcessingAppCommand(this, eventArgs);
          return eventArgs.OutputParamsList; 
        }
      }
      private Object executeCommandLock = new Object();
    }
