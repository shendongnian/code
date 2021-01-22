    public class DeletePersonCommand: ICommand
    {
         private Person personToDelete;
         public DeletePersonCommand(Person personToDelete)
         {
             this.personToDelete = personToDelete;
         }
 
         public void Execute()
         {
            doSomethingWith(personToDelete);
         }
    }
