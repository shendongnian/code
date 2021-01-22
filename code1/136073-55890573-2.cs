    public class Person : IComparable, IEquatable<Person>
    {
    	//Some code hidden
    
    	public bool Equals(Person other)
    	{
    		if (Age == other.Age && Name == other.Name)
    		{
    			return true;
    		}
    		else
    		{
    			return false;
    		}
    	}
    }
