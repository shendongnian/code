       private void MyMethod (parameterList)
       {  MyMethod(ParameterList, 0)l }
    
       private void MyMethod(ParameterList, int attempt)
       {
          try { HelperMethod(); }
          catch(SomeSpecificException)
          {
              if (attempt < MAXATTEMPTS)
                  MyMethod(ParameterList, ++attempt);
              else throw;
          }
       }
              
