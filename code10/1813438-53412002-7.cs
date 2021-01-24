       public GetValue() {
         try {
           do some action with possible throw exception1
    
           // Catastrophy here: AccessViolationException! System is in ruins!
           do some action with possible throw exception2
    
           return value;
         }
         catch (Exception ex) { // AccessViolationException will be caught...
           // ...and the disaster will have been masked as being just WrapedException
           throw new WrapedException("MyNewMessage", ex);
         }
       }
