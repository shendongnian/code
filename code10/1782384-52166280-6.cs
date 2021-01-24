      TestReport GetTestReport() {
        // throws NullReferenceException (yes, GenerateReport() has a bug)
        return testReporter.GenerateReport(); 
      }
      catch (Exception ex) {
        // Bad Practice: here we hide hideous NullReferenceException, 
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
