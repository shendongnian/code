    class MyClass
    {
       public Func<loan, user, bool> SendStuffAction ;
    
       MyClass()
       {
          SendStuffAction = SendStuff;
       }
    
       bool SendStuff(loan loanVar, user userVar)
       {
          return true;
       }
    }
