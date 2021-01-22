      int frameCount = 0;
      do {
        frameCount++;
        stackFrame = stackTrace.GetFrame( frameCount );
        stackFrameMethod = stackFrame.GetMethod();
        stackType = stackFrameMethod.ReflectedType;
      } while ( stackType.IsSubclassOf( typeof( Test )) || stackType == typeof( Test ) );
      return stackFrameMethod;
    }
  }
