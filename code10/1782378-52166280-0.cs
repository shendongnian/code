      TestReport GetTestReport() {
        // throws NullReferenceException 
        return testReporter.GenerateReport(); 
      }
      catch (Exception ex) {
        //Bad Practice: here we hide NullReferenceException, 
        // but throw innocent TestRunnerException
        throw new TestRunnerException("Failed to generate report.", ex);
      }
      
      ...
      try { 
        GetTestReport();
      }
      catch (TestRunnerException ex) {
        // Nothing serious: Tests report fails, let's do nothing
        // Under the hood: the routine went very wrong  - 
        // NullReferenceException - in GenerateReport(); 
        ;
      }
