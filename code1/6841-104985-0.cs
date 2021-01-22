    class DeletePersonCommand : ICommand
    {
       private Person person;
       public DeletePersonCommand(Person person)
       {
          this.person = person;
       }
    
       public void Execute()
       {
          RealDelete(person);
       }
    }
