    public class People : IEnumerable
    {
    	private Person[] _people;
    	public People(Person[] pArray)
    	{
    		_people = new Person[pArray.Length];
    
    		for (int i = 0; i < pArray.Length; i++)
    		{
    			_people[i] = pArray[i];
    		}
    	}
       IEnumerator IEnumerable.GetEnumerator()
       {
    	   for (int i=0; i < _people.Length; i++) {
    	       yield return _people[i];
    	   }
       }
    }
