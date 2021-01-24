    // 1
    private async Task LittleFunction()
    {
      var operand = new SomeObject();
      var notUsedResult =  await SomeAsyncOperationWith(operand); 
      SomeOtherOperationsWith(operand); 
    }
    // 2
    private async Task LittleFunction()
    {
      var operand = new SomeObject();
      await SomeAsyncOperationWith(operand); 
      SomeOtherOperationsWith(operand); 
    }
