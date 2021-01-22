    public class DeletePersonCommand: ICommand<Person>
    {
    	public DeletePersonCommand(IPersonService personService)
    	{  
    		this.personService = personService;
    	}
    		
    	public void Execute(Person person)
    	{
    		this.personService.DeletePerson(person);
    	}
    }
