      var task1 = new AsyncDelegate1(Compute1);
      var result1 = new ComputationResult("task1");
      task1.BeginInvoke(42, result1, 
        new AsyncCallback((ia) => {
          AsyncResult result = ia as AsyncResult;
          (result.AsyncDelegate as AsyncDelegate1).EndInvoke(ia);
          CommonCallback(result.AsyncState as ComputationResult);
        }), 
        result1);
