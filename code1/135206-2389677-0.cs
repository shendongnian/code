    public class PersonList : IEnumerable<Person>
    {
    	public List<Person> myIntenalList;
    	
    	public IEnumerator<Person> GetEnumerator()
    	{
    	     return this.myInternalList.GetEnumerator();
    	}
     
    	Person CustomFunction()
    	{...}
    }
