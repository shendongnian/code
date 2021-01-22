      AsyncResult result = (AsyncResult)iresult;
      if (result.AsyncDelegate is AsyncDelegate1) {
        (result.AsyncDelegate as AsyncDelegate1).EndInvoke(iresult);
      }
      else if (result.AsyncDelegate is AsyncDelegate2) {
        (result.AsyncDelegate as AsyncDelegate2).EndInvoke(iresult);
      }
      //etc...
      ComputationResult answer = result.AsyncState as ComputationResult;
