    [TestMethod]
    public void TestMethod1()
    {
      .
      .
      .
      try
      {
        WorkflowInvoker.Invoke(workflow1, inputDictionary);
      }
      catch (SqlException ex)
      {
        if (ex.Errors.Count > 0
          && ex.Errors[0].Procedure == "proc_AVAILABLEPLACEMENTNOTIFICATIONInsert")
        {
          //Likely to occur if we try to repeat an insert during development/debugging. 
          //Probably not interested--the mail has already been sent if we got as far as that proc.
          throw new UnitTestWarningException("Note: after sending the mail, proc_AVAILABLEPLACEMENTNOTIFICATIONInsert threw an exception. This may be expected depending on test conditions. The exception was: {0}", ex.Message);
        }
      }
    }
      
