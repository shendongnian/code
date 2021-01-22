    public class Person : IComparable
    {
    	public string Name { get; set; }
    	public int Age { get; set; }
    
    	public int CompareTo(object obj)
    	{
    		Person otherPerson = obj as Person;
    		if (otherPerson == null)
    		{
    			throw new ArgumentNullException();
    		}
    		else
    		{
    			return Age.CompareTo(otherPerson.Age);
    		}
    	}
    }
